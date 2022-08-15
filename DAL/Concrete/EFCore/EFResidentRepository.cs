using DAL.Abstract;
using DAL.DbContexts;
using DAL.EFBase;
using Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Concrete.EFCore
{
    public class EFResidentRepository : EFBaseRepository<Resident, ApartmentManagementDbContext>, IResidentRepository
    {
        public EFResidentRepository(ApartmentManagementDbContext context) : base(context)
        {
        }
    }
}
