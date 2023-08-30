﻿using ecommerce.admin.Features.Roles.Queries.Models;
using ecommerce.Base;
using ecommerce.Domain.AppMetaData.Admin;
using ecommerce.Domain.Attribute;
using ecommerce_shared.Swagger;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce.Controllers.SuperAdmin
{

    [ApiController]
    [ApiGroup(ApiGroupName.SuperAdmin)]

    public class RoleController: ApiController
    {


        //[CheckTokenInRedis]
        [HttpGet(RoleRouter.List)]
        public async Task<IActionResult> GetAllRole([FromQuery]GetAllRoleQuery query)
        {

            var response = await this.Mediator.Send(query);
            return response;

        }

    }
}
