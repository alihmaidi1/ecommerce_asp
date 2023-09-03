using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.models.Users.Auth.Commands
{
    public  class LoginUserCommand:IRequest<JsonResult>
    {

        public string UserName{ get; set; }

        public string Password { get; set; }    
    }
}
