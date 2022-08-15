using Microsoft.AspNetCore.Mvc;
using Models.Common;

namespace API.Configuration.Filters.Auth
{
    public class PermissionAttribute : TypeFilterAttribute
    {
        public PermissionAttribute(PermissionEnum permission) : base(typeof(PermissionFilter))
        {
            Arguments = new object[] { permission };
        }
    }
}
