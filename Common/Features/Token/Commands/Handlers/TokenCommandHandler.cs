using Common.Features.Token.Commands.Models;
using ecommerce.Domain.SharedResources;
using ecommerce_shared.OperationResult;
using ecommerce_shared.OperationResult.Base;
using MediatR;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Features.Token.Commands.Handlers
{
    public class TokenCommandHandler : OperationResult,
        IRequestHandler<RefreshTheTokenCommand, OperationResultBase<string>>
    {
        public TokenCommandHandler(IStringLocalizer<SharedResource> stringLocalizer) : base(stringLocalizer)
        {

        }

        public Task<OperationResultBase<string>> Handle(RefreshTheTokenCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
