using ecommerce.Dto.Results.Admin.Pages;
using ecommerce.Dto.Results.Admin.Pages.Query;
using ecommerce.Dto.Results.Admin.Pages;
using ecommerce_shared.OperationResult.Base;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.admin.Features.Pages.Queries.Models
{
    public class GetPageById : IRequest<OperationResultBase<GetPageByIdResult>>
    {
        public Guid Id;
    }
}
