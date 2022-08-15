using AutoMapper;
using Business.Abstract;
using Business.Configuration.Extensions;
using Business.Configuration.Response;
using Business.Configuration.Validator.FluentValidation.RevenueValidation;
using DAL.Abstract;
using DTO.Revenue;
using Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class RevenueService : IRevenueService
    {
        private readonly IRevenueRepository _repository;
        private readonly IMapper _mapper;
        private readonly IPropertyService _propertyService;
        public RevenueService(IRevenueRepository repository, IMapper mapper, IPropertyService propertyService)
        {
            _repository = repository;
            _mapper = mapper;
            _propertyService = propertyService;
        }

        public CommandResponse Delete(Revenue revenue)
        {
            _repository.Delete(revenue);
            return new CommandResponse
            {
                Success = true,
                Message = $"Revenue deleted successfully."
            };
        }

        public IEnumerable<RevenueGetResponse> GetAll()
        {
            var data = _repository.GetAll();
            var mappedData = data.Select(x => _mapper.Map<RevenueGetResponse>(x)).ToList();
            return mappedData;
        }

        public RevenueGetResponse GetById(int id)
        {
            var data = _repository.Get(x => x.Id == id);
            var mappedData = _mapper.Map<RevenueGetResponse>(data);
            return mappedData;
        }

        public CommandResponse Insert(RevenueInsertRequest request)
        {
            //validation
            var validator = new RevenueInsertRequestValidator();
            validator.Validate(request).ThrowIfException();

            //Calculate Debt and Update to Database
            _propertyService.DebtUpdate(request.PropertyId, request.Price, request.Paid);

            //Add request to database
            var entity = _mapper.Map<Revenue>(request);
            _repository.Add(entity);
            _repository.SaveChanges();

            return new CommandResponse
            {
                Success = true,
                Message = $"Revenue inserted successfully."
            };
        }

        public CommandResponse Update(RevenueUpdateRequest request)
        {
            //validation
            var validator = new RevenueUpdateRequestValidator();
            validator.Validate(request).ThrowIfException();

            var entity = _repository.Get(x => x.Id == request.Id);
            if (entity == null)
            {
                return new CommandResponse
                {
                    Success = false,
                    Message = $"Customer not found. Id={request.Id}"
                };
            }

            //Calculate Debt and Update to Database
            _propertyService.DebtUpdate(request.PropertyId, request.Price, request.Paid);

            //Update request
            var mapped = _mapper.Map<Revenue>(request);
            _repository.Update(mapped);
            _repository.SaveChanges();

            return new CommandResponse
            {
                Success = true,
                Message = $"Revenue updated successfully."
            };
        }
    }
}
