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


        [HttpPost(AdminRouter.Update)]
        public async Task<IActionResult> Update(UpdateAdminCommand request)
        {
            var response = await this.Mediator.Send(request);
            return response;

        }


        [HttpPost(AdminRouter.Block)]
        public async Task<IActionResult> Block([FromRoute]Guid Id)
        {
            var response = await this.Mediator.Send(new BlockAdminCommand { Id=Id});
            return response;

        }


        [HttpPost(AdminRouter.UnBlock)]
        public async Task<IActionResult> UnBlock([FromRoute] Guid Id)
        {
            var response = await this.Mediator.Send(new UnBlockAdminCommand { Id = Id });
            return response;

        }



        [HttpGet(AdminRouter.Get)]
        public async Task<IActionResult> Get([FromRoute] Guid Id)
        {
            var response = await this.Mediator.Send(new GetAdminQuery { Id = Id });
            return response;

        }
    }
}
