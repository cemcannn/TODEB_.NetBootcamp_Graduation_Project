using Models.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; }
        public string TRIdNumber { get; set; }
        public string Email { get; set; }
        public UserPassword Password { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public UserRoleEnum Role { get; set; }
        public ICollection<UserPermission> Permissions { get; set; }
        public Property Property { get; set; }
        public bool IsTenant { get; set; }
        public ICollection<Vehicle> Vehicles { get; set; }
    }
}
