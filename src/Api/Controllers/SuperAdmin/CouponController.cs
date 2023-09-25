//using ecommerce.Base;
//using ecommerce.Domain.AppMetaData.SuperAdmin;
//using ecommerce.Domain.Attributes;
//using ecommerce.Domain.Enum;
//using ecommerce.models.SuperAdmin.Currency;
//using ecommerce_shared.Swagger;
//using Microsoft.AspNetCore.Mvc;

//namespace ecommerce.Controllers.SuperAdmin
//{


//    [AppAuthorize(RoleEnum.SuperAdmin)]
//    [ApiGroup(ApiGroupName.SuperAdmin)]
//    public class CouponController: ApiController
//    {


//        [HttpPut(CouponRouter.Store)]
//        public async Task<IActionResult> Store()
//        {
//            var response = await Mediator.Send(new ToggleCurrencyCommand { Id = id });
//            return response;
//        }

//    }
//}
