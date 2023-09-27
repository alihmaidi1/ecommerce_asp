using ecommerce.admin.Roles.Queries.Models;
using ecommerce.Base;
using ecommerce.Domain.AppMetaData.Admin;
using ecommerce.Domain.AppMetaData.SuperAdmin;
using ecommerce.Domain.Attributes;
using ecommerce.Domain.Enum;
using ecommerce.models.SuperAdmin.Slider.Command;
using ecommerce.models.SuperAdmin.Slider.Query;
using ecommerce_shared.Swagger;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce.Controllers.SuperAdmin
{
    [AppAuthorize(RoleEnum.SuperAdmin)]
    [ApiGroup(ApiGroupName.SuperAdmin)]

    public class SliderController: ApiController
    {

        [HttpPost(SliderRouter.Store)]
        public async Task<IActionResult> store(StoreSliderCommand request)
        {
            var response = await this.Mediator.Send(request);
            return response;

        }


        [HttpPost(SliderRouter.GetAll)]
        public async Task<IActionResult> GetAll(GetAllSliderQuery request)
        {
            var response = await this.Mediator.Send(request);
            return response;

        }



        [HttpPut(SliderRouter.Update)]
        public async Task<IActionResult> Update([FromBody]UpdateSliderCommand request)
        {
            var response = await this.Mediator.Send(request);
            return response;

        }



        [HttpDelete(SliderRouter.Delete)]
        public async Task<IActionResult> Delete([FromRoute]Guid id)
        {
            var response = await this.Mediator.Send(new DeleteSliderCommand { Id=id});
            return response;

        }


        [HttpPost(SliderRouter.Get)]
        public async Task<IActionResult> Get([FromRoute]Guid id)
        {
            var response = await this.Mediator.Send(new GetSliderQuery { Id=id});
            return response;

        }

    }
}
