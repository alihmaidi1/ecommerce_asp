using ecommerce_shared.OperationResult.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.user.Features.Auth.Commands.Models
{
    internal class LoginUserCommand: IRequest<OperationResultBase<string>>
    {

        public string UserName { get; set; }


        public string Password { get; set; }
    }
}
