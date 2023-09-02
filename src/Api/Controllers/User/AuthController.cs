using ecommerce.Base;
using ecommerce.Domain.AppMetaData.User;
using ecommerce.models.Users.Auth.Commands;
using ecommerce_shared.Swagger;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce.Controllers.User
{

    [ApiGroup(ApiGroupName.User)]

    public class AuthController: ApiController
    {

        
        [HttpPost(AuthUserRouter.Create)]
        public async Task<IActionResult> CreateUser([FromBody] AddUserCommand command)
        {

            var response = await this.Mediator.Send(command);
            return response;
        }
        [HttpPost(AuthUserRouter.Confirm)]

        public async Task<IActionResult> ConfirmAccount([FromBody]ConfirmAccountCommand request)
        {
            var response=await this.Mediator.Send(request);
            return response;
        }


        //[HttpPost(AuthUserRouter.Login)]

        //public async Task<IActionResult> LoginUser([FromBody] LoginUserCommand command)
        //{

        //    var response=await this.Mediator.Send(command);
        //    return response;

        //}

        //[HttpPost(AuthUserRouter.Logout)]
        //public async Task<IActionResult> Logout(LogoutUserCommand command)
        //{
        //    var response=await this.Mediator.Send(command); 
        //    return response;

        //}

    }
}
