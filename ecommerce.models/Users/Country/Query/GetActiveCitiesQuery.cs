using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce.models.Users.Country.Query;

public class GetActiveCitiesQuery:IRequest<JsonResult>
{
    
    public Guid Id { get; set; }
    
}