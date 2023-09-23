using ecommerce.Domain.Entities.Category;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.models.SuperAdmin.Category.Command
{
    public class UnActiveCategoryCommand:IRequest<JsonResult>
    {


        public Guid Id { get; set; }

    }
}
