using ecommerce_shared.Swagger;
using ecommerce.Base;
using ecommerce.Domain.AppMetaData.User;
using ecommerce.models.Users.Country.Query;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce.Controllers.User;

[ApiGroup(ApiGroupName.User)]

public class CountryController:ApiController
{
    
    
    [HttpGet(CountryRouter.GetAll)]

    public async Task<IActionResult> GetAll()
    {

        var response=await this.Mediator.Send(new GetAllCountryQuery());
        return response;

    }
    
    [HttpGet(CountryRouter.ActiveCity)]

    public async Task<IActionResult> GetActiveCities([FromRoute] Guid id)
    {

        var response=await this.Mediator.Send(new GetActiveCitiesQuery{Id = id});
        return response;

    }

    
    
    
}