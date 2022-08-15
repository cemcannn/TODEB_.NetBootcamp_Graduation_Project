using Models.Common;
using System.Collections.Generic;

namespace DTO.User
{
    public class UserRegisterRequest
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public UserRoleEnum Role { get; set; }
        public ICollection<PermissionEnum> UserPermissions { get; set; }
    }
}