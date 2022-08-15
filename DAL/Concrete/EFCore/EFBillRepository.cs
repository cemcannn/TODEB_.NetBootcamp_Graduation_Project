using DAL.Abstract;
using DAL.DbContexts;
using DAL.EFBase;
using Models.Entities;

namespace DAL.Concrete.EFCore
{
    public class EFBillRepository : EFBaseRepository<Bill, ApartmentManagementDbContext>, IBillRepository
    {
        public EFBillRepository(ApartmentManagementDbContext context) : base(context)
        {
        }
    }
}
