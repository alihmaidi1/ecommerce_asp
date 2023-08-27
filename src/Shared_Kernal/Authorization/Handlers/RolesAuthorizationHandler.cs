using ecommerce.Domain.Abstract;
using ecommerce.infrutructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce_shared.Authorization.Handlers
{
    public class RolesAuthorizationHandler : AuthorizationHandler<RolesAuthorizationRequirement>
    {
        public UserManager<Account> UserManager;

        public RolesAuthorizationHandler(UserManager<Account> UserManager) { 
        
            this.UserManager = UserManager; 
        }
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, RolesAuthorizationRequirement requirement)
        {

            
            if (context.User==null||context.User?.Identity?.IsAuthenticated==false)
            {

                context.Fail();
                return;

            }
            var Roles = requirement.AllowedRoles;

            var Id= context.User.Claims.FirstOrDefault(r=>r.Type==ClaimTypes.NameIdentifier).Value;
            Account User=  UserManager.FindByIdAsync(Id).Result;
            var UserRole= UserManager.GetRolesAsync(User).Result;
            bool RolesExists=Roles.Any(r => UserRole.Any(ur => ur.Equals(r)));
            
            if (RolesExists) {

                context.Succeed(requirement);

            }
            else
            {

                context.Fail();
            }

            return ;
            
        }
    }
}
