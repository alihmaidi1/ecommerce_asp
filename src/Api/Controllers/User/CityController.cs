using ecommerce_shared.Swagger;
using ecommerce.Base;
using ecommerce.Domain.AppMetaData.User;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce.Controllers.User;

[ApiGroup(ApiGroupName.User)]

public class CityController:ApiController
{
    
    
    [HttpGet(CityRouter.getAll)]

    public async Task<IActionResult> GetAll([FromRoute] Guid id)
    {

        var response=await this.Mediator.Send(new GetAllCountryQuery());
        return response;

    }


    
}