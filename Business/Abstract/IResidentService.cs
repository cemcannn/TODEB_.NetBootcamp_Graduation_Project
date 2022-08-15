using Business.Configuration.Response;
using DTO.Resident;
using Models.Entities;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IResidentService
    {
        IEnumerable<ResidentGetResponse> GetAll();
        ResidentGetResponse GetById(int id);
        CommandResponse Insert(ResidentInsertRequest request);
        CommandResponse Update(ResidentUpdateRequest request);
        CommandResponse Delete(Resident resident);
    }
}
