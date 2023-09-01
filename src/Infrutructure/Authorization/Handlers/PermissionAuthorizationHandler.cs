using ecommerce.Domain.Entities.Identity;
using ecommerce.infrutructure;
using ecommerce.infrutructure.Authorization.Requirements;
using ecommerce.infrutructure.ExtensionMethod;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace ecommerce_shared.Authorization.Handlers
{
    public class PermissionAuthorizationHandler : AuthorizationHandler<PermissionRequirement>
    {

        public UserManager<Account> UserManager;
        public ApplicationDbContext DBContext ;

        public PermissionAuthorizationHandler(UserManager<Account> UserManager, ApplicationDbContext DBContext) {
            
            this.UserManager = UserManager;
            this.DBContext  = DBContext;

        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
        {

            if (context.User == null||context.User.Identity.IsAuthenticated==false)
            {
                return;
            }
            Guid Id=new Guid(context.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
            var claims = DBContext.GetAccountCalims(Id);   
            var RequiredPermission = requirement.Permission;
            var exists = claims.Any(c=>c.ClaimValue.Equals(RequiredPermission));
            if (exists)
            {
                context.Succeed(requirement);
            }
            else
            {

                context.Fail();
            }

            return;

           

        }
    }
}
