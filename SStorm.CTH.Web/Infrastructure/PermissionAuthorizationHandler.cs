using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SStorm.CTH.Web.Infrastructure
{
    public class PermissionAuthorizationHandler : AuthorizationHandler<PermissionRequirement>
    {
        public PermissionAuthorizationHandler()
        {

        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
        {

            if (context.User == null)
            {
                return;
            }
            // dummy await
            await Task.Run(() => (true));
            //  check user has the permission required
            // for the authorization to succeed.

            // todo: uncomment below lines
            //if (context.User.HasClaim(ClaimTypes.Role, requirement.Permission.ToString()))
            //{
                context.Succeed(requirement);
                return;
            //}

        }
    }
}
