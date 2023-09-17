using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.models.SuperAdmin.Admin.Commands
{
    public class StoreAdminCommand:IRequest<JsonResult>
    {

        public string UserName { get; set; }


        public string Email { get; set; }

        public string Password { get; set; }    


        public Guid RoleId { get; set; }











    }
}
