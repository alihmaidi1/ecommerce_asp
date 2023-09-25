//using ecommerce.admin.Country.Queries.Models;
//using ecommerce.Base;
//using ecommerce.Domain.AppMetaData.Admin;
//using ecommerce.Domain.Attributes;
//using ecommerce.Domain.Enum;
//using ecommerce.models.SuperAdmin.Country;
//using ecommerce_shared.Swagger;
//using Microsoft.AspNetCore.Mvc;

//namespace ecommerce.Controllers.SuperAdmin
//{

//    [AppAuthorize(RoleEnum.SuperAdmin)]

//    [ApiGroup(ApiGroupName.SuperAdmin)]
//    public class CountryController: ApiController
//    {


//        [HttpGet(CountryRouter.List)]
//        public async Task<IActionResult> GetAllCountry()
//        {

//            var response = await Mediator.Send(new GetAllCountriesQuery());
//            return response;
//        }


//        [HttpGet(CountryRouter.Get)]
//        public async Task<IActionResult> GetCountry([FromRoute]Guid id)
//        {
         
//            var response=await Mediator.Send(new GetCountryQuery { Id=id});
//            return response;

//        }



//        [HttpPut(CountryRouter.Active)]
//        public async Task<IActionResult> Active([FromRoute] Guid id)
//        {

//            var response = await Mediator.Send(new ActiveCountryCommand { Id = id });
//            return response;

//        }



//        [HttpPut(CountryRouter.UnActive)]
//        public async Task<IActionResult> UnActive([FromRoute] Guid id)
//        {

//            var response = await Mediator.Send(new UnActiveCountryCommand { Id = id });
//            return response;

//        }
//    }
//}
