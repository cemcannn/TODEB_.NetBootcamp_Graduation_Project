using DAL.Abstract;
using DAL.DbContexts;
using DAL.EFBase;
using Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DAL.Concrete.EFCore
{
    public class EFUserRepository:EFBaseRepository<User, ApartmentManagementDbContext>, IUserRepository
    {
        public EFUserRepository(ApartmentManagementDbContext context) : base(context)
        {
        }
        
        public User GetUserWithPassword(string email)
        {
            return Context.Users.Include(x => x.Password).FirstOrDefault(x => x.Email == email);
        }
    }
}
