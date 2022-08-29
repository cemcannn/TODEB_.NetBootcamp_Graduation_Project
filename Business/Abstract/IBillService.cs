using Business.Configuration.Response;
using DTO.Bill;
using Models.Entities;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IBillService
    {
        public IEnumerable<BillGetResponse> GetAll();
        public BillGetResponse GetById(int id);
        public CommandResponse Insert(BillInsertRequest request);
        public CommandResponse Update(BillUpdateRequest request);
        public CommandResponse Delete(Bill bill);
        public BillGetResponse GetBillWithProperty(int id);
    }
}
