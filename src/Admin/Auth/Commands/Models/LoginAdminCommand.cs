﻿using ecommerce_shared.OperationResult.Base;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.admin.Auth.Commands.Models
{
    public class LoginAdminCommand : IRequest<JsonResult>
    {

        public string Username { get; set; }

        public string Password { get; set; }

    }
}
