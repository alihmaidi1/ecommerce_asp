using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.models.SuperAdmin.Category.Query
{
    public class GetAllCategoryAsTreeQuery:IRequest<JsonResult>
    {


        public string? OrderBy { get; set; }
        public bool? status { get; set; }


    }
}
