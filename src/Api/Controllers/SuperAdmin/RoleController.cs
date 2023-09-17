using ecommerce.admin.Roles.Queries.Models;
using ecommerce.Base;
using ecommerce.Domain.AppMetaData.Admin;
using ecommerce.Domain.Attributes;
using ecommerce.Domain.Enum;
using ecommerce.models.SuperAdmin.Role.Commands;
using ecommerce.models.SuperAdmin.Role.Query;
using ecommerce_shared.Swagger;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce.Controllers.SuperAdmin
{

    [AppAuthorize(RoleEnum.SuperAdmin)]
    [ApiGroup(ApiGroupName.SuperAdmin)]

    public class RoleController: ApiController
    {


        [HttpGet(RoleRouter.List)]
        public async Task<IActionResult> GetAllRole()
        {
            var response = await this.Mediator.Send(new GetAllRoleQuery());
            return response;

        }


        [HttpGet(RoleRouter.Get)]
        public async Task<IActionResult> GetRole([FromRoute]string id)
        {
            var response = await this.Mediator.Send(new GetRoleQuery(id));
            return response;

        }


        [HttpGet(RoleRouter.Permissions)]
        public async Task<IActionResult> GetPermission()
        {
            var response = await this.Mediator.Send(new GetPermission());
            return response;

        }



        [HttpPost(RoleRouter.Store)]
        public async Task<IActionResult> Store([FromBody]StoreRolecommand request)
        {
            var response = await this.Mediator.Send(request);
            return response;

        }



        [HttpPut(RoleRouter.Update)]
        public async Task<IActionResult> Update([FromBody] UpdateRoleCommand request)
        {
            var response = await this.Mediator.Send(request);
            return response;

        }



        [HttpDelete(RoleRouter.Delete)]
        public async Task<IActionResult> Delete([FromRoute]Guid Id)
        {
            var response = await this.Mediator.Send(new DeleteRoleCommand { Id=Id});
            return response;

        }
    }
}
