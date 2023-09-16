using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.models.SuperAdmin.Role.Query
{
    public class GetRoleQuery:IRequest<JsonResult>
    {


        public GetRoleQuery(string Id) {
        
            this.Id = Id;   
        }
        public string Id { get; set; }

    }
}
