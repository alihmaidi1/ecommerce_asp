using Amazon.Runtime.Internal;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.admin.Features.Password.Models
{
    public class CheckCodeCommand:IRequest<JsonResult>
    {
    
        public string Code { get; set; }    

    }
}
