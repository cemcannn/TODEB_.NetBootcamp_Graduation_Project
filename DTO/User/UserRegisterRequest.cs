using Models.Common;
using Models.Entities;
using System.Collections.Generic;

namespace DTO.User
{
    public class UserRegisterRequest
    {
        public string FullName { get; set; }
        public string TRIdNumber { get; set; }
        public string Email { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public UserRoleEnum Role { get; set; }
        public ICollection<PermissionEnum> UserPermissions { get; set; }
        public bool IsTenant { get; set; }
    }
}