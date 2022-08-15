using DAL.Abstract;
using DAL.DbContexts;
using DAL.EFBase;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete.EFCore
{
    public class EFVehicleRepository : EFBaseRepository<Vehicle, ApartmentManagementDbContext>, IVehicleRepository
    {
        public EFVehicleRepository(ApartmentManagementDbContext context) : base(context)
        {
        }
    }
}
