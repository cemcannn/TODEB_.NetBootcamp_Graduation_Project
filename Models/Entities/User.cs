using Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public UserPassword Password { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public int RoleId { get; set; }
        [ForeignKey("RoleId")]
        public UserRoleEnum Role { get; set; }
        public ICollection<UserPermission> Permissions { get; set; }
    }
}
