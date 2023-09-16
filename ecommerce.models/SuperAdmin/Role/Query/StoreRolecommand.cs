using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.models.SuperAdmin.Role.Query
{
    public class StoreRolecommand:IRequest<JsonResult>
    {

        public string Name { get; set; }


        public List<string> Permissions { get; set; }



    }
}
