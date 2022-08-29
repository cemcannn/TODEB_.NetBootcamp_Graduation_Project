using AutoMapper;
using Business.Abstract;
using Business.Configuration.Extensions;
using Business.Configuration.Response;
using Business.Configuration.Validator.FluentValidation.PaymentValidation;
using DAL.Abstract;
using DTO.Payment;

namespace Business.Concrete
{
    public class PaymentService : IPaymentService
    {
        private readonly IPropertyService _propertyService;
        private readonly IBillRepository _billRepository;
        private readonly IRevenueRepository _revenueRepository;
        public PaymentService(IPropertyService propertyService, IRevenueRepository revenueRepository, IBillRepository billRepository)
        {
            _propertyService = propertyService;
            _revenueRepository = revenueRepository;
            _billRepository = billRepository;
        }

        public CommandResponse PayBill(PayBillRequest request)
        {
            //Validation
            var validator = new PayBillRequestValidator();
            validator.Validate(request).ThrowIfException();
            
            var bill = _billRepository.Get(x=>x.Id == request.BillId);
            
            if (bill.IsPaid)
            {
                return new CommandResponse
                {
                    Success = false,
                    Message = $"Revenue already paid."
                };
            }

            bill.IsPaid = true;
            _billRepository.Update(bill);
            
            //Calculate Debt and Update to Database
            _propertyService.DebtUpdate(request.PropertyId, bill.Price, bill.IsPaid);

            return new CommandResponse
            {
                Success = true,
                Message = $"Bill paid successfully."
            };
        }

        public CommandResponse PayRevenue(PayRevenueRequest request)
        {
            //Validation
            var validator = new PayRevenueRequestValidator();
            validator.Validate(request).ThrowIfException();

            var revenue = _revenueRepository.Get(x => x.Id == request.RevenueId);

            if (revenue.IsPaid)
            {
                return new CommandResponse
                {
                    Success = false,
                    Message = $"Revenue already paid."
                };
            }

            //var creditCard = _repository.Get(request.Id);
            revenue.IsPaid = true;
            _revenueRepository.Update(revenue);

            //Calculate Debt and Update to Database
            _propertyService.DebtUpdate(request.PropertyId, revenue.Price, revenue.IsPaid);

            return new CommandResponse
            {
                Success = true,
                Message = $"Revenue paid successfully."
            };
        }
    }
}
