using ecommerce.admin.Features.Auth.Commands.Models;
using ecommerce.models.SuperAdmin.Brand.Commands;
using ecommerce_shared.OperationResult;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.admin.Features.Brand.Command.Handlers
{
    public class BrandHandler : OperationResult,
        IRequestHandler<AddBrandCommand, JsonResult>

    {


        public Task<JsonResult> Handle(AddBrandCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
