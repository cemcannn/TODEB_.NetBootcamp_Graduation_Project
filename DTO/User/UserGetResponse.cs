using Models.Common;
using Models.Entities;
using System.Collections.Generic;

namespace DTO.User
{
    public class UserGetResponse
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string TRIdNumber { get; set; }
        public string Email { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public UserRoleEnum Role { get; set; }
        public ICollection<UserPermission> UserPermissions { get; set; }
        public Models.Entities.Property Property { get; set; }
        public bool IsTenant { get; set; }
        public ICollection<Models.Entities.Vehicle> Vehicles { get; set; }
    }
}
