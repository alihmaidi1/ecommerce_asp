using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.models.SuperAdmin.Brand.Query
{
    public class GetAllBrandQuery:IRequest<JsonResult>
    {

        public string? OrderBy { get; set; }

        public bool? isDes { get; set; }    

        public int? pageNumber { get; set; }
        public int? pageSize { get; set; }
    }
}
