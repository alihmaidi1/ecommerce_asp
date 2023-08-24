﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.user.Features.Auth.Commands.Models
{
    public class LogoutUserCommand: IRequest<JsonResult>
    {

        public string Token { get; set; }

    }
}