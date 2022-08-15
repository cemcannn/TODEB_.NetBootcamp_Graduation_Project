using Business.Configuration.Response;
using DTO.Revenue;
using Models.Entities;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IRevenueService
    {
        IEnumerable<RevenueGetResponse> GetAll();
        RevenueGetResponse GetById(int id);
        CommandResponse Insert(RevenueInsertRequest request);
        CommandResponse Update(RevenueUpdateRequest request);
        CommandResponse Delete(Revenue revenue);
    }
}
