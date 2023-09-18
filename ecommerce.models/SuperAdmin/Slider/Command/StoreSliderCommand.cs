using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.models.SuperAdmin.Slider.Command
{
    public class StoreSliderCommand:IRequest<JsonResult>
    {

        public string Url { get; set; }

        public int Rank { get; set; }
    
    
    }
}
