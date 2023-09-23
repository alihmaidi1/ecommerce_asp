using ecommerce.Domain.Entities.Slider;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.models.SuperAdmin.Slider.Command
{
    public class UpdateSliderCommand:IRequest<JsonResult>
    {


        public Guid Id { get; set; }    

        public int Rank { get; set; }

        public string url { get; set; }




    }
}
