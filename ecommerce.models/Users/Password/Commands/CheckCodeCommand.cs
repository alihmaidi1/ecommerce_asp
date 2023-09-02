using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.models.Users.Password.Commands
{
    public class CheckCodeCommand:IRequest<JsonResult>
    {

        public string Code { get; set; }    

    }
}
