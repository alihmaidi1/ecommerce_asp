using ecommerce.Base;
using ecommerce.Domain.AppMetaData.Admin;
using SchmeaEnum = ecommerce_shared.Enums.JwtSchema;
using ecommerce_shared.Swagger;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ecommerce.Domain.Attributes;
using ecommerce.admin.Features.Password.Models;

namespace ecommerce.Controllers.SuperAdmin
{


    [ApiGroup(ApiGroupName.SuperAdmin)]
    public class PasswordController: ApiController
    {

        [HttpPost(PasswordRouter.ResetPassword)]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordCommand request)
        {

            var response=await this.Mediator.Send(request);

            return response;
        }

        [AppAuthorize(AuthenticationSchemes = nameof(SchmeaEnum.ResetPassword))]
        [HttpPost(PasswordRouter.CheckCode)]
        public async Task<IActionResult> CheckCode(CheckCodeCommand request)
        {
            var response= await this.Mediator.Send(request);    
            return response;
        }



    }
}
