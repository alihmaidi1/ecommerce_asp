using ecommerce.admin.Features.Country.Queries.Models;
using ecommerce.Base;
using ecommerce.Domain.AppMetaData.Admin;
using ecommerce.Domain.Attributes;
using ecommerce.Domain.Enum;
using ecommerce_shared.Swagger;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce.Controllers.SuperAdmin
{

    [AppAuthorize(RoleEnum.SuperAdmin)]

    [ApiGroup(ApiGroupName.SuperAdmin)]
    public class CountryController: ApiController
    {


        [HttpGet(CountryRouter.List)]
        public async Task<IActionResult> GetAllCountry()
        {

            var response = await Mediator.Send(new GetAllCountriesQuery());
            return response;
        }


        [HttpGet(CountryRouter.Get)]
        public async Task<IActionResult> GetCountry([FromRoute]GetCountryQuery request)
        {
         
            var response=await Mediator.Send(request);
            return response;

        }



    }
}
