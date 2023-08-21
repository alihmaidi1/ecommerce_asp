using ecommerce_shared.OperationResult.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Features.Token.Commands.Models
{
    public class RefreshTheTokenCommand: IRequest<OperationResultBase<string>>
    {


        public string RefreshToken { get; set; }
    }
}
