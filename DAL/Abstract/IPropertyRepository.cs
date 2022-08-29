using DAL.EFBase;
using Models.Entities;

namespace DAL.Abstract
{
    public interface IPropertyRepository : IEfBaseRepository<Property>
    {
        Property GetProperty(int id);
        Property GetUser(int id);
    }
}
