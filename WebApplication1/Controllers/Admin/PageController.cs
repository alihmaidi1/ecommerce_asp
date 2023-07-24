using ecommerce.admin.Pages.Queries.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class PageController : ControllerBase
    {
        private readonly IMediator Mediator;
        public PageController(IMediator Mediator)
        {
            this.Mediator = Mediator;

        }

        [HttpGet("List")]
        public async Task<IActionResult> GetPageList()
        {

            var response =await this.Mediator.Send(new GetAllPagesQuery());
            return Ok(response);
        }


    }
}
