using DAL.EFBase;
using Models.Entities;

namespace DAL.Abstract
{
    public interface IBillRepository : IEfBaseRepository<Bill>
    {
        Bill GetBillWithDetails(int id);
    }
}
