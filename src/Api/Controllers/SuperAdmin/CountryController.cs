using ecommerce.admin.Features.Country.Queries.Models;
using ecommerce.Base;
using ecommerce.Domain.AppMetaData.Admin;
using ecommerce.Domain.Attribute;
using ecommerce_shared.Swagger;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce.Controllers.SuperAdmin
{

    [ApiGroup(ApiGroupName.SuperAdmin)]
    [ApiController]
    public class CountryController: ApiController
    {


        [HttpGet(CountryRouter.List)]
        [CheckTokenInRedis(Roles ="SuperAdmin")]

        public async Task<IActionResult> GetAllCountry([FromQuery]GetAllCountriesQuery request)
        {

            var response = await Mediator.Send(request);
            return response;
        }


        [HttpGet(CountryRouter.Get)]
        public async Task<IActionResult> GetCountry(GetCountryQuery request)
        {
         
            var response=await Mediator.Send(request);
            return response;

        }



    }
}
