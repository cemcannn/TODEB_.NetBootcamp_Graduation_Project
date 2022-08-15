using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Models.Entities;

namespace DAL.DbContexts
{
    public class ApartmentManagementDbContext : DbContext
    {
        private IConfiguration _configuration;
        public ApartmentManagementDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public DbSet<Property> Properties { get; set; }
        public DbSet<Resident> Residents { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Revenue> Revenues { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserPassword> UserPasswords { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = _configuration.GetConnectionString("MsComm");
            base.OnConfiguring(optionsBuilder.UseSqlServer(connectionString));
        }
    }
}
