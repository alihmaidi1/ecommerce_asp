using ecommerce_shared.OperationResult.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.admin.Features.Auth.Commands.Models
{
    public class LoginAdmin: IRequest<OperationResultBase<string>>
    {

        public string Username { get; set; }

        public string Password { get; set; }

    }
}
