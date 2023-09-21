using ecommerce.admin.Country.Queries.Models;
using ecommerce.Base;
using ecommerce.Domain.AppMetaData.Admin;
using ecommerce.Domain.AppMetaData.SuperAdmin;
using ecommerce.Domain.Attributes;
using ecommerce.Domain.Enum;
using ecommerce.models.SuperAdmin.Currency;
using ecommerce_shared.Swagger;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce.Controllers.SuperAdmin
{

    [AppAuthorize(RoleEnum.SuperAdmin)]

    [ApiGroup(ApiGroupName.SuperAdmin)]


    public class CurrencyController: ApiController
    {



        [HttpGet(CurrencyRouter.List)]
        public async Task<IActionResult> GetAllCurrency()
        {
            var response = await Mediator.Send(new GetAllCurrencyQuery());
            return response;
        }



        [HttpPut(CurrencyRouter.Toggle)]
        public async Task<IActionResult> Toggle([FromRoute] Guid id)
        {
            var response = await Mediator.Send(new ToggleCurrencyCommand { Id= id });
            return response;
        }





    }
}
