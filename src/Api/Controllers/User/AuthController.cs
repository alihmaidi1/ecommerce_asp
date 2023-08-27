using ecommerce.admin.Features.Pages.Commands.Models;
using ecommerce.Base;
using ecommerce.Domain.AppMetaData.Admin;
using ecommerce.Domain.AppMetaData.User;
using ecommerce.user.Features.Auth.Commands.Models;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce.Controllers.User
{

    public class AuthController: ApiController
    {

        [HttpPost(AuthUserRouter.Create)]
        public async Task<IActionResult> CreateUser([FromBody] AddUserCommand command)
        {

            var response = await this.Mediator.Send(command);
            return response;
        }

        [HttpPost(AuthUserRouter.Login)]

        public async Task<IActionResult> LoginUser([FromBody] LoginUserCommand command)
        {

            var response=await this.Mediator.Send(command);
            return response;

        }

        [HttpPost(AuthUserRouter.Logout)]
        public async Task<IActionResult> Logout(LogoutUserCommand command)
        {
            var response=await this.Mediator.Send(command); 
            return response;

        }

    }
}
