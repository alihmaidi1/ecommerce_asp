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
    public class CategoryController : ApiController
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





        [HttpGet(CategoryRouter.GetAllAsTree)]
        public async Task<IActionResult> GetAllAsTree([FromQuery] GetAllCategoryAsTreeQuery request)
        {

            var response = await Mediator.Send(request);
            return response;
        }


        [HttpGet(CategoryRouter.Get)]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {

            var response = await Mediator.Send(new GetCategoryQuery { Id = id });
            return response;
        }



        [HttpPut(CategoryRouter.UnActive)]
        public async Task<IActionResult> UnActive([FromRoute] Guid id)
        {


            var response = await Mediator.Send(new UnActiveCategoryCommand { Id = id });
            return response;
        }



        [HttpPut(CategoryRouter.ActiveCategory)]
        public async Task<IActionResult> ActiveCategory([FromRoute] Guid id)
        {


            var response = await Mediator.Send(new ActiveCategoryCommand { Id = id });
            return response;
        }


        [HttpPut(CategoryRouter.Update)]
        public async Task<IActionResult> Update([FromBody] UpdateCategoryCommand request)
        {

            var response = await Mediator.Send(request);
            return response;
        }



        [HttpDelete(CategoryRouter.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {

            var response = await Mediator.Send(new DeleteCategoryCommand { Id = id });
            return response;
        }

    }
}
