using Common.Features.Token.Commands.Models;
using ecommerce.Base;
using ecommerce.Domain.AppMetaData.Common;
using ecommerce.user.Features.Auth.Commands.Models;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce.Controllers.Common
{
    public class TokenController: ApiController
    {
        [HttpPost(TokenRouter.RefreshTheToken)]
        public async Task<IActionResult> RefreshTheToken( [FromBody]RefreshTheTokenCommand command)
        {

            var response =await this.Mediator.Send(command);
            return response;


        }

    }
}
