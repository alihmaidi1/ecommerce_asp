using Amazon.Runtime.Internal;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.admin.Password.Models
{
    public class ForgetPasswordCommand : IRequest<JsonResult>
    {

        public string Email { get; set; }

    }
}
