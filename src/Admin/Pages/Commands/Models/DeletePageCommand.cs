﻿using ecommerce_shared.OperationResult.Base;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.admin.Features.Pages.Commands.Models
{
    public class DeletePageCommand: IRequest<JsonResult>
    {
 
        public Guid Id { get; set; }
    
    }
}