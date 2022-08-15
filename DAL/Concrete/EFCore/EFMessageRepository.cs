using DAL.Abstract;
using DAL.DbContexts;
using DAL.EFBase;
using Models.Entities;

namespace DAL.Concrete.EFCore
{
    public class EFMessageRepository : EFBaseRepository<Message, ApartmentManagementDbContext>, IMessageRepository
    {
        public EFMessageRepository(ApartmentManagementDbContext context) : base(context)
        {
        }
    }
}
