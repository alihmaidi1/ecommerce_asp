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
using Microsoft.AspNetCore.Mvc;

namespace ecommerce.admin.Pages.Queries.Models
{
    public class GetPageById : IRequest<JsonResult>
    {
        public Guid Id;
    }
}
