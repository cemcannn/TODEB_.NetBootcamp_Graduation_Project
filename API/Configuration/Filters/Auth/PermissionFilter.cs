using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.DependencyInjection;
using Models.Common;
using System.Linq;

namespace API.Configuration.Filters.Auth
{
    public class PermissionFilter : IAuthorizationFilter
    {
        private readonly PermissionEnum _permission;

        public PermissionFilter(PermissionEnum permission)
        {
            _permission = permission;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var cacheClaim = context.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "PermissionCache");
            if (cacheClaim == null)
                context.Result = new BadRequestResult();

            var cacheManager = context.HttpContext.RequestServices.GetService<IDistributedCache>();

            var strCachePermissions = cacheManager.GetString(cacheClaim.Value);

            if (string.IsNullOrWhiteSpace(strCachePermissions))
            {
                context.Result = new ForbidResult("You don't have permission to access this resource");
            }
            else
            {
                var cachePermissionList =
                    System.Text.Json.JsonSerializer.Deserialize<PermissionEnum[]>(strCachePermissions); 

                if (!cachePermissionList.Any(x => x == _permission)) 
                    context.Result = new ForbidResult("You don't have permission to access this resource");
            }
        }
    }
}
