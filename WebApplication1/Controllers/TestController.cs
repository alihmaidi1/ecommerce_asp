using Microsoft.AspNetCore.Mvc;

namespace ecommerce.Controllers
{
    [ApiController]

    [Route("api/[controller]/[action]")]

    public class TestController: ControllerBase
    {
        [HttpGet]
        public string Helloworld()
        {

            return "sdfsdsdf";

        }

    }
}
