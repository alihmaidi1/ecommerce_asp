using ecommerce.admin.Pages.Queries.Result;
using ecommerce.Domain.Entities;
using ecommerce_shared.OperationResult;
using ecommerce_shared.OperationResult.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.admin.Pages.Queries.Models
{
    public class GetAllPagesQuery:IRequest<OperationResultBase<List<GetAllPagesResult>>>
    {
    }
}
