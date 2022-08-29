using DAL.Abstract;
using DAL.DbContexts;
using DAL.EFBase;
using Microsoft.EntityFrameworkCore;
using Models.Entities;
using System.Linq;

namespace DAL.Concrete.EFCore
{
    public class EFBillRepository : EFBaseRepository<Bill, ApartmentManagementDbContext>, IBillRepository
    {
        public EFBillRepository(ApartmentManagementDbContext context) : base(context)
        {
        }
        public Bill GetBillWithDetails(int id)
        {
            return Context.Bills.Include(x => x.Property).FirstOrDefault();
        }
    }
}
