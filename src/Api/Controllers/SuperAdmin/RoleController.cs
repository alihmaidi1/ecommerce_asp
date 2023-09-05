using ecommerce.admin.Features.Roles.Queries.Models;
using ecommerce.Base;
using ecommerce.Domain.AppMetaData.Admin;
using ecommerce.Domain.Attribute;
using ecommerce.Domain.Attributes;
using ecommerce.Domain.Enum;
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

    }
}
