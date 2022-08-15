using DAL.EFBase;
using Models.Entities;

namespace DAL.Abstract
{
    public interface IUserRepository:IEfBaseRepository<User>
    {
        User GetUserWithPassword(string email);
    }
}
