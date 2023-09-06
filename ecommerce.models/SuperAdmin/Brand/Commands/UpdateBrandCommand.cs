using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.models.SuperAdmin.Brand.Commands
{
    public class UpdateBrandCommand:IRequest<JsonResult>
    {

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Logo { get; set; }
    
    }
}
