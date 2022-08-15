using Business.Configuration.Response;
using DTO.Vehicle;
using Models.Entities;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IVehicleService
    {
        IEnumerable<VehicleGetResponse> GetAll();
        VehicleGetResponse GetById(int id);
        CommandResponse Insert(VehicleInsertRequest request);
        CommandResponse Update(VehicleUpdateRequest request);
        CommandResponse Delete(Vehicle vehicle);
    }
}
