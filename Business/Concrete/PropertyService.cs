using AutoMapper;
using Business.Abstract;
using Business.Configuration.Extensions;
using Business.Configuration.Helper;
using Business.Configuration.Response;
using Business.Configuration.Validator.FluentValidation.PropertyValidation;
using DAL.Abstract;
using DTO.Property;
using Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class PropertyService : IPropertyService
    {
        private readonly IPropertyRepository _repository;
        private readonly IMapper _mapper;
        public PropertyService(IPropertyRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public CommandResponse Delete(Property property)
        {
            _repository.Delete(property);
            return new CommandResponse
            {
                Success = true,
                Message = $"Property deleted successfully."
            };
        }

        public IEnumerable<PropertyGetResponse> GetAll()
        {
            var data = _repository.GetAll();
            var mappedData = data.Select(x => _mapper.Map<PropertyGetResponse>(x)).ToList();
            return mappedData;
        }

        public PropertyGetResponse GetById(int id)
        {
            var data = _repository.Get(x => x.Id == id);
            var mappedData = _mapper.Map<PropertyGetResponse>(data);
            return mappedData;
        }

        public CommandResponse Insert(PropertyInsertRequest request)
        {
            //validation
            var validator = new PropertyInsertRequestValidator();
            validator.Validate(request).ThrowIfException();

            //Add request to database
            var entity = _mapper.Map<Property>(request);
            _repository.Add(entity);
            _repository.SaveChanges();

            return new CommandResponse
            {
                Success = true,
                Message = $"Property inserted successfully."
            };
        }

        public CommandResponse Update(PropertyUpdateRequest request)
        {
            //validation
            var validator = new PropertyUpdateRequestValidator();
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

            //Update request
            var mapped = _mapper.Map(request, entity);
            _repository.Update(mapped);
            _repository.SaveChanges();

            return new CommandResponse
            {
                Success = true,
                Message = $"Property updated successfully."
            };
        }

        public void DebtUpdate(int id, int price, bool paid)
        {
            var data = _repository.Get(x => x.Id == id);
            var totalDebt = CalculatorHelper.CalculateDebt(data.Debt, price, paid);
            data.Debt = totalDebt;
            _repository.Update(data);
            _repository.SaveChanges();
        }
        
        public PropertyGetResponse GetProperty(int id)
        {
            var data = _repository.GetProperty(id);
            var mappedData = _mapper.Map<PropertyGetResponse>(data);
            return mappedData;
        }
    }
}