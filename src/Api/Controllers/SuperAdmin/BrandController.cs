using ecommerce.admin.Features.Country.Queries.Models;
using ecommerce.Base;
using ecommerce.Domain.AppMetaData.Admin;
using ecommerce.Domain.Attributes;
using ecommerce.Domain.Enum;
using ecommerce.models.SuperAdmin.Brand.Commands;
using ecommerce.models.SuperAdmin.Brand.Query;
using ecommerce_shared.Swagger;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce.Controllers.SuperAdmin
{

    [AppAuthorize(RoleEnum.SuperAdmin)]

    [ApiGroup(ApiGroupName.SuperAdmin)]
    public class BrandController: ApiController
    {


        [HttpPost(BrandRouter.Add)]
        public async Task<IActionResult> AddBrand([FromBody]AddBrandCommand request)
        {

            var response = await Mediator.Send(request);
            return response;
        }



        [HttpPost(BrandRouter.List)]
        public async Task<IActionResult> GetAllBtand([FromQuery]GetAllBrandQuery request)
        {

            var response = await Mediator.Send(request);
            return response;
        }


        [HttpPut(BrandRouter.Update)]
        public async Task<IActionResult> UpdateBrand([FromBody]UpdateBrandCommand request)
        {

            var response = await Mediator.Send(request);
            return response;
        }


        [HttpDelete(BrandRouter.Delete)]
        public async Task<IActionResult> DeleteBrand(Guid Id)
        {
            var response = await Mediator.Send(new DeletebrandCommand(Id));
            return response;
        }

    }
}
