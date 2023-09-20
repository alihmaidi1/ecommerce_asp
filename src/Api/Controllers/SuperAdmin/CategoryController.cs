using ecommerce.Base;
using ecommerce.Domain.AppMetaData.Admin;
using ecommerce.Domain.AppMetaData.SuperAdmin;
using ecommerce.Domain.Attributes;
using ecommerce.Domain.Enum;
using ecommerce.models.SuperAdmin.Brand.Commands;
using ecommerce.models.SuperAdmin.Category.Command;
using ecommerce.models.SuperAdmin.Category.Query;
using ecommerce_shared.Swagger;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce.Controllers.SuperAdmin
{

    [AppAuthorize(RoleEnum.SuperAdmin)]

    [ApiGroup(ApiGroupName.SuperAdmin)]
    public class CategoryController: ApiController
    {

        [HttpPost(CategoryRouter.Store)]
        public async Task<IActionResult> AddCategory([FromBody] StoreCategoryCommand request)
        {

            var response = await Mediator.Send(request);
            return response;
        }



        [HttpGet(CategoryRouter.GetAll)]
        public async Task<IActionResult> GetAll([FromQuery] GetAllCategory request)
        {

            var response = await Mediator.Send(request);
            return response;
        }


        [HttpPut(CategoryRouter.Update)]
        public async Task<IActionResult> Update([FromBody] UpdateCategoryCommand request)
        {

            var response = await Mediator.Send(request);
            return response;
        }


    }
}
