using AutoMapper;
using Business.Abstract;
using Business.Configuration.Extensions;
using Business.Configuration.Response;
using Business.Configuration.Validator.FluentValidation.VehicleValidation;
using DAL.Abstract;
using DTO.Vehicle;
using Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _repository;
        private readonly IMapper _mapper;
        public VehicleService(IVehicleRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public CommandResponse Delete(Vehicle vehicle)
        {
            _repository.Delete(vehicle);
            return new CommandResponse
            {
                Success = true,
                Message = $"Vehicle deleted successfully."
            };
        }

        public IEnumerable<VehicleGetResponse> GetAll()
        {
            var data = _repository.GetAll();
            var mappedData = data.Select(x => _mapper.Map<VehicleGetResponse>(x)).ToList();
            return mappedData;
        }

        public VehicleGetResponse GetById(int id)
        {
            var data = _repository.Get(x => x.Id == id);
            var mappedData = _mapper.Map<VehicleGetResponse>(data);
            return mappedData;
        }

        public CommandResponse Insert(VehicleInsertRequest request)
        {
            //validation
            var validator = new VehicleInsertRequestValidator();
            validator.Validate(request).ThrowIfException();

            //Add request to database
            var entity = _mapper.Map<Vehicle>(request);
            _repository.Add(entity);
            _repository.SaveChanges();

            return new CommandResponse
            {
                Success = true,
                Message = $"Vehicle inserted successfully."
            };
        }

        public CommandResponse Update(VehicleUpdateRequest request)
        {
            //validation
            var validator = new VehicleUpdateRequestValidator();
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
                Message = $"Vehicle updated successfully."
            };
        }
    }
}
