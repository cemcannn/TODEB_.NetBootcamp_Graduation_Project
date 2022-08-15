using DAL.Abstract;
using DAL.DbContexts;
using DAL.EFBase;
using Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Concrete.EFCore
{
    public class EFRevenueRepository : EFBaseRepository<Revenue, ApartmentManagementDbContext>, IRevenueRepository
    {
        public EFRevenueRepository(ApartmentManagementDbContext context) : base(context)
        {
        }
    }
}
