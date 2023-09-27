using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.models.SuperAdmin.Slider.Query
{
    public class GetAllSliderQuery:IRequest<JsonResult>
    {

        
        public int? pageNumber { get; set; }
        public int? pageSize { get; set; }

    }
}
