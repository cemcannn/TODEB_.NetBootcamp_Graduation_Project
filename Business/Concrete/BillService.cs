using AutoMapper;
using Business.Abstract;
using Business.Configuration.Extensions;
using Business.Configuration.Response;
using Business.Configuration.Validator.FluentValidation.BillValidation;
using DAL.Abstract;
using DTO.Bill;
using Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class BillService : IBillService
    {
        private readonly IBillRepository _repository;
        private readonly IPropertyRepository _propertyRepository;
        private readonly IMapper _mapper;
        private readonly IPropertyService _propertyService;

        public BillService(IBillRepository repository, IMapper mapper, IPropertyRepository propertyRepository, IPropertyService propertyService)
        {
            _repository = repository;
            _mapper = mapper;
            _propertyRepository = propertyRepository;
            _propertyService = propertyService;
        }

        public CommandResponse Delete(Bill bill)
        {
            _repository.Delete(bill);
            return new CommandResponse
            {
                Success = true,
                Message = $"Bill deleted successfully."
            };
        }

        public IEnumerable<BillGetResponse> GetAll()
        {
            var data = _repository.GetAll();
            var mappedData = data.Select(x => _mapper.Map<BillGetResponse>(x)).ToList();
            return mappedData;
        }


        public BillGetResponse GetBillWithProperty(int id)
        {
            var data = _repository.GetBillWithDetails(id);
            var mappedData = _mapper.Map<BillGetResponse>(data);
            return mappedData;
        }

        public BillGetResponse GetById(int id)
        {
            var data = _repository.Get(x => x.Id == id);
            var mappedData = _mapper.Map<BillGetResponse>(data);
            return mappedData;
        }

        public CommandResponse Insert(BillInsertRequest request)
        {
            //Validation
            var validator = new BillInsertRequestValidator(); 
            validator.Validate(request).ThrowIfException();

            //Calculate Debt and Update to Database
            _propertyService.DebtUpdate(request.PropertyId, request.Price, request.IsPaid);

            //Add Request to Database  
            var entity = _mapper.Map<Bill>(request);
            _repository.Add(entity);
            _repository.SaveChanges();

            return new CommandResponse
            {
                Success = true,
                Message = $"Bill inserted successfully."
            };
        }

        public CommandResponse Update(BillUpdateRequest request)
        {
            //validation
            var validator = new BillUpdateRequestValidator();
            validator.Validate(request).ThrowIfException();

            var entity = _repository.Get(x => x.Id == request.Id);
            if (entity == null)
            {
                return new CommandResponse
                {
                    Success = false,
                    Message = $"Bill not found. Id={request.Id}"
                };
            }


            //Calculate Debt and Update to Database
            _propertyService.DebtUpdate(request.PropertyId, request.Price, request.IsPaid);

            //Update request
            var mapped = _mapper.Map(request, entity);
            _repository.Update(mapped);
            _repository.SaveChanges();

            return new CommandResponse
            {
                Success = true,
                Message = $"Bill updated successfully."
            };
        }
    }
}
