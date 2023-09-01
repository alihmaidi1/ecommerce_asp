using ecommerce.admin.Features.Password.Models;
using ecommerce.Base;
using ecommerce.Domain.AppMetaData.Admin;
using ecommerce_shared.Swagger;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce.Controllers.SuperAdmin
{


    [ApiController]
    [ApiGroup(ApiGroupName.SuperAdmin)]
    public class PasswordController: ApiController
    {

        [HttpPost(PasswordRouter.ResetPassword)]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordCommand request)
        {

            var response=await this.Mediator.Send(request);

            return response;
        }



    }
}
