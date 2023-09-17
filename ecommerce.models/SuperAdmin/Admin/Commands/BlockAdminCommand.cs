using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.models.SuperAdmin.Admin.Commands
{
    public class BlockAdminCommand:IRequest<JsonResult>
    {

        public Guid Id { get; set; }

    }
}
