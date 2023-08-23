using ecommerce.admin.Features.Auth.Commands.Models;
using ecommerce_shared.OperationResult.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.admin.Features.Auth.Commands.Handlers
{
    internal class AuthCommandHandlers : IRequestHandler<LoginAdminCommand, OperationResultBase<string>>
    {
        public Task<OperationResultBase<string>> Handle(LoginAdminCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
