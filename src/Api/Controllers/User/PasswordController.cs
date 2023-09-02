using ecommerce.Base;
using ecommerce.Domain.AppMetaData.User;
using ecommerce.Domain.Attributes;
using ecommerce.models.Users.Password.Commands;
using ecommerce_shared.Enums;
using ecommerce_shared.Swagger;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce.Controllers.User
{
    [ApiController]
    [ApiGroup(ApiGroupName.User)]

    public class PasswordController: ApiController
    {

        [HttpPost(PasswordRouter.ResetEmail)]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordCommand request)
        {

            var response = await this.Mediator.Send(request);

            return response;
        }

        [AppAuthorize(AuthenticationSchemes = nameof(JwtSchema.ResetPassword))]
        [HttpPost(PasswordRouter.CheckCode)]
        public async Task<IActionResult> CheckCode(CheckCodeCommand request)
        {
            var response = await this.Mediator.Send(request);
            return response;
        }


    }
}
