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
    }
}
