using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.models.SuperAdmin.Brand.Commands
{
    public class AddBrandCommand:IRequest<JsonResult>
    {

        public string Name { get; set; }
        public string Image { get; set; }
    }
}
