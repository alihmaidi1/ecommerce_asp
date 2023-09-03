using ecommerce.admin.Features.Auth.Commands.Models;
using ecommerce.Base;
using ecommerce.Domain.AppMetaData.Admin;
using ecommerce.Domain.AppMetaData.User;
using ecommerce.Domain.Attributes;
using ecommerce.Domain.Enum;
using ecommerce_shared.Swagger;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce.Controllers.Admin
{

    [ApiGroup(ApiGroupName.SuperAdmin)]
    public class AuthController: ApiController
    {


        [HttpPost(AuthAdminRouter.Login)]

        public async Task<IActionResult> LoginAdmin([FromBody] LoginAdminCommand command,CancellationToken Token)
        {

            var response = await this.Mediator.Send(command,Token);
            return response;

        }

        [AppAuthorize(RoleEnum.SuperAdmin)]
        [HttpPost(AuthAdminRouter.Logout)]
        public async Task<IActionResult> LogoutAdmin()
        {

            var response = await this.Mediator.Send(new LogoutCommand());
            return response;
        }

    }
}
