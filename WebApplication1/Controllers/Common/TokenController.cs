using ecommerce.Base;
using ecommerce.Domain.AppMetaData.Common;
using ecommerce.user.Features.Auth.Commands.Models;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce.Controllers.Common
{
    public class TokenController: ApiController
    {
        [HttpPost(TokenRouter.RefreshTheToken)]
        public async Task<IActionResult> RefreshTheToken( AddUserCommand command)
        {


            return null;


        }

    }
}
