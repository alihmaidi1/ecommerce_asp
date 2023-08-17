using ecommerce.Domain.Enum;
using ecommerce_shared.OperationResult;
using ecommerce_shared.OperationResult.Base;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.admin.Features.Pages.Commands.Models
{
    public class AddPageCommand : IRequest<JsonResult>
    {
        public PageName Name { get; set; }

        public string Content { get; set; }


    }
}
