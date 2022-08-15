using AutoMapper;
using Business.Abstract;
using Business.Configuration.Extensions;
using Business.Configuration.Response;
using Business.Configuration.Validator.FluentValidation.ResidentValidation;
using DAL.Abstract;
using DTO.Resident;
using Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class ResidentService : IResidentService
    {
        private readonly IResidentRepository _repository;
        private readonly IMapper _mapper;
        public ResidentService(IResidentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public CommandResponse Delete(Resident resident)
        {
            _repository.Delete(resident);
            return new CommandResponse
            {
                Success = true,
                Message = $"Resident deleted successfully."
            };
        }

        public IEnumerable<ResidentGetResponse> GetAll()
        {
            var data = _repository.GetAll();
            var mappedData = data.Select(x => _mapper.Map<ResidentGetResponse>(x)).ToList();
            return mappedData;
        }

        public ResidentGetResponse GetById(int id)
        {
            var data = _repository.Get(x => x.Id == id);
            var mappedData = _mapper.Map<ResidentGetResponse>(data);
            return mappedData;
        }

        public CommandResponse Insert(ResidentInsertRequest request)
        {
            //validation
            var validator = new ResidentInsertRequestValidator();
            validator.Validate(request).ThrowIfException();

            //Add request to database
            var entity = _mapper.Map<Resident>(request);
            _repository.Add(entity);
            _repository.SaveChanges();

            return new CommandResponse
            {
                Success = true,
                Message = $"Resident inserted successfully."
            };
        }

        public CommandResponse Update(ResidentUpdateRequest request)
        {
            //validation
            var validator = new ResidentUpdateRequestValidator();
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
            var mapped = _mapper.Map<Resident>(request);
            _repository.Update(mapped);
            _repository.SaveChanges();

            return new CommandResponse
            {
                Success = true,
                Message = $"Resident updated successfully."
            };
        }
    }
}
