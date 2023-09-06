using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.models.SuperAdmin.Brand.Commands
{
    public class DeletebrandCommand:IRequest<JsonResult>
    {


        public DeletebrandCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
