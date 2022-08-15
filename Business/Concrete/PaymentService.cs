using AutoMapper;
using Business.Abstract;
using Business.Configuration.Helper;
using Business.Configuration.Response;
using DAL.Abstract;
using DTO.Payment;
using DTO.Property;

namespace Business.Concrete
{
    public class PaymentService : IPaymentService
    {
        private readonly IMapper _mapper;
        private readonly IPropertyService _propertyService;
        private readonly ICreditCardService _creditCardService;
        private readonly IBillRepository _billRepository;
        private readonly IRevenueRepository _revenueRepository;
        public PaymentService(IMapper mapper, IPropertyService propertyService, IRevenueRepository revenueRepository, IBillRepository billRepository)
        {
            _mapper = mapper;
            _propertyService = propertyService;
            _revenueRepository = revenueRepository;
            _billRepository = billRepository;
        }

        public CommandResponse PayBill(PaymentPostRequest request)
        {
            //var validator = new PropertyInsertRequestValidator();
            //validator.Validate(request).ThrowIfException();

            var bill = _billRepository.Get(x=>x.Id == request.BillId);

            //var creditCard = _repository.Get(request.Id);
            bill.Paid = true;
            _billRepository.Update(bill);
            
            //Calculate Debt and Update to Database
            _propertyService.DebtUpdate(request.PropertyId, bill.Price, bill.Paid);

            return new CommandResponse
            {
                Success = true,
                Message = $"Bill paid successfully."
            };
        }

        public CommandResponse PayRevenue(PaymentPostRequest request)
        {
            //var validator = new PropertyInsertRequestValidator();
            //validator.Validate(request).ThrowIfException();

            var revenue = _revenueRepository.Get(x => x.Id == request.RevenuesId);

            //var creditCard = _repository.Get(request.Id);
            revenue.Paid = true;
            _revenueRepository.Update(revenue);

            //Calculate Debt and Update to Database
            _propertyService.DebtUpdate(request.PropertyId, revenue.Price, revenue.Paid);

            return new CommandResponse
            {
                Success = true,
                Message = $"Bill paid successfully."
            };
        }
    }
}
