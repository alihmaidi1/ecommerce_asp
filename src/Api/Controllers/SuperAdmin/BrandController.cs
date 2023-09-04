using ecommerce.admin.Features.Country.Queries.Models;
using ecommerce.Base;
using ecommerce.Domain.AppMetaData.Admin;
using ecommerce.Domain.Attributes;
using ecommerce.Domain.Enum;
using ecommerce.models.SuperAdmin.Brand.Commands;
using ecommerce_shared.Swagger;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce.Controllers.SuperAdmin
{

    [ApiGroup(ApiGroupName.SuperAdmin)]
    [AppAuthorize(RoleEnum.SuperAdmin)]
    public class BrandController: ApiController
    {


        [HttpPost(BrandRouter.Add)]
        public async Task<IActionResult> AddBrand([FromBody]AddBrandCommand request)
        {

            var response = await Mediator.Send(request);
            return response;
        }


    }
}
