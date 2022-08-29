using DAL.Abstract;
using DAL.DbContexts;
using DAL.EFBase;
using Microsoft.EntityFrameworkCore;
using Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Concrete.EFCore
{
    public class EFPropertyRepository : EFBaseRepository<Property, ApartmentManagementDbContext>, IPropertyRepository
    {
        public EFPropertyRepository(ApartmentManagementDbContext context) : base(context)
        {
        }

        public Property GetProperty(int id)
        {
            return Context.Properties.Include(x => x.Bills).FirstOrDefault();
        }

        public Property GetUser(int id)
        {
            return Context.Properties.Include(x => x.Bills).FirstOrDefault();
        }
    }
}
