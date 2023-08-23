using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce.Base
{
    public class ApiController: ControllerBase
    {
        private IMediator mediatorinstance;
        protected  IMediator Mediator=> mediatorinstance??=HttpContext.RequestServices.GetService<IMediator>();


    }
}
