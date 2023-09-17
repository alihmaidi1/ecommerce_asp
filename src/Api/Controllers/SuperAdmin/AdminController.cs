using ecommerce.Base;
using ecommerce.Domain.AppMetaData.Admin;
using ecommerce.Domain.AppMetaData.SuperAdmin;
using ecommerce.models.SuperAdmin.Admin.Commands;
using ecommerce.models.SuperAdmin.Admin.Query;
using ecommerce_shared.Swagger;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce.Controllers.SuperAdmin
{

    [ApiGroup(ApiGroupName.SuperAdmin)]
    public class AdminController:ApiController
    {

        [HttpGet(AdminRouter.GetAll)]
        public async Task<IActionResult> GetAllAdmin()
        {
            var response = await this.Mediator.Send(new GetAllAdminQuery());
            return response;

        }



        [HttpPost(AdminRouter.Store)]
        public async Task<IActionResult> Store(StoreAdminCommand request)
        {
            var response = await this.Mediator.Send(request);
            return response;

        }


    }
}
