using ecommerce.admin.Features.Auth.Commands.Models;
using ecommerce.Base;
using ecommerce.Domain.AppMetaData.Admin;
using ecommerce.Domain.AppMetaData.User;
using ecommerce.user.Features.Auth.Commands.Models;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce.Controllers.Admin
{

    public class AuthController: ApiController
    {


        [HttpPost(AuthAdminRouter.Login)]

        public async Task<IActionResult> LoginAdmin([FromBody] LoginAdminCommand command)
        {

            var response = await this.Mediator.Send(command);
            return response;

        }

    }
}
