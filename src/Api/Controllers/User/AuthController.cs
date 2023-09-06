using ecommerce.Base;
using ecommerce.Domain.AppMetaData.User;
using ecommerce.Domain.Attributes;
using ecommerce.models.Users.Auth.Commands;
using ecommerce_shared.Services.Authentication.Factory;
using ecommerce_shared.Swagger;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce.Controllers.User
{

    [ApiGroup(ApiGroupName.User)]

    public class AuthController: ApiController
    {

        public IAuthenticationFactory AuthenticationFactory;
        public AuthController(IAuthenticationFactory AuthenticationFactory) { 
        
            this.AuthenticationFactory = AuthenticationFactory;
        }

        [HttpPost(AuthUserRouter.AuthWithGoogle)]
        public async Task<IActionResult> AuthWithGoogle([FromBody]AuthenticateWithGoogleCommand request)
        {
            
            var response = await Mediator.Send(request);
            return response;

        }



        [HttpPost(AuthUserRouter.AuthWithGithub)]
        public async Task<IActionResult> AuthWithGithub([FromBody] AuthenticateWithGithubCommand request)
        {

            var response=await Mediator.Send(request);
            return response;

        }

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


        [HttpPost(AuthUserRouter.Login)]

        public async Task<IActionResult> LoginUser([FromBody] LoginUserCommand command)
        {

            var response=await this.Mediator.Send(command);
            return response;

        }

        [HttpPost(AuthUserRouter.Logout)]
        [UserAuthorizeAtrribute]
        public async Task<IActionResult> Logout()
        {
            var response = await this.Mediator.Send(new LogoutUserCommand());
            return response;

        }

    }
}
