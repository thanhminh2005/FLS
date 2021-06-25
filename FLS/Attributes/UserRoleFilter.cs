using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FLS.Attributes
{
    public class UserRoleFilter : Attribute, IAuthorizationFilter
    {
        private readonly string _permission;

        public UserRoleFilter(string permission)
        {
            _permission = permission;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string role = "";
            if (context.HttpContext.User.Claims == null || !context.HttpContext.User.Claims.Any())
            {
                context.Result = new ForbidResult("Unauthorized access");
            } 
            else
            {
                var userIdClaim = context.HttpContext.User.Claims.FirstOrDefault(x => x.Type.Equals("user_id"));
                if (userIdClaim != null)
                {
                    var userId = userIdClaim.Value;
                }
                else
                {
                    context.Result = new ForbidResult("Unauthorized access - Faulty token");
                }
                var roleClaim = context.HttpContext.User.Claims.FirstOrDefault(x => x.Type.Equals("user_role"));
                if (roleClaim != null)
                {   
                    var userId = roleClaim.Value;
                }
                else
                {
                    context.Result = new ForbidResult("Unauthorized access - Faulty token");
                }
                if (!_permission.Contains(role))
                {
                    context.Result = new ForbidResult();
                }

            }
        }
    }
}
