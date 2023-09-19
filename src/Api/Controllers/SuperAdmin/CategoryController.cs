using ecommerce.Base;
using ecommerce.Domain.AppMetaData.Admin;
using ecommerce.Domain.AppMetaData.SuperAdmin;
using ecommerce.Domain.Attributes;
using ecommerce.Domain.Enum;
using ecommerce.models.SuperAdmin.Brand.Commands;
using ecommerce.models.SuperAdmin.Category.Command;
using ecommerce_shared.Swagger;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce.Controllers.SuperAdmin
{

    [AppAuthorize(RoleEnum.SuperAdmin)]

    [ApiGroup(ApiGroupName.SuperAdmin)]
    public class CategoryController: ApiController
    {

        [HttpPost(CategoryRouter.Store)]
        public async Task<IActionResult> AddBrand([FromBody] StoreCategoryCommand request)
        {

            var response = await Mediator.Send(request);
            return response;
        }





    }
}
