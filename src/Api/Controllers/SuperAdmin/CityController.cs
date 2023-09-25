//using ecommerce.Base;
//using ecommerce.Domain.AppMetaData.Admin;
//using ecommerce.Domain.AppMetaData.SuperAdmin;
//using ecommerce.Domain.Attributes;
//using ecommerce.Domain.Enum;
//using ecommerce.models.SuperAdmin.City.Command;
//using ecommerce.models.SuperAdmin.Country;
//using ecommerce_shared.Swagger;
//using Microsoft.AspNetCore.Mvc;

//namespace ecommerce.Controllers.SuperAdmin
//{

//    [AppAuthorize(RoleEnum.SuperAdmin)]

//    [ApiGroup(ApiGroupName.SuperAdmin)]
//    public class CityController: ApiController
//    {


//        [HttpPut(CityRouter.Toggle)]
//        public async Task<IActionResult> Toggle([FromRoute] Guid id)
//        {

//            var response = await Mediator.Send(new ToggleCityCommand { Id = id });
//            return response;

//        }

//    }
//}
