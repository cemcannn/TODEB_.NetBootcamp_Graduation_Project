using Business.Configuration.Response;
using DTO.Property;
using Models.Entities;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IPropertyService
    {
        public IEnumerable<PropertyGetResponse> GetAll();
        public PropertyGetResponse GetById(int id);
        public CommandResponse Insert(PropertyInsertRequest request);
        public CommandResponse Update(PropertyUpdateRequest request);
        public CommandResponse Delete(Property property);
        public void DebtUpdate(int id, int price, bool paid);
        public PropertyGetResponse GetProperty(int id);
    }
}
