using ecommerce.Domain.Entities;
using ecommerce.Dto.Results.Admin.Pages.Query;
using ecommerce_shared.OperationResult;
using ecommerce_shared.OperationResult.Base;
using ecommerce_shared.Pagination;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.admin.Features.Pages.Queries.Models
{
    public class GetAllPagesQuery : IRequest<OperationResultBase<PageList<GetAllPagesResult>>>
    {

        public int ? pageNumber { get; set; }
        public int? pageSize { get; set; }

    }
}
