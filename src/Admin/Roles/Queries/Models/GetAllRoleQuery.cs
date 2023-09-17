using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.admin.Roles.Queries.Models
{
    public class GetAllRoleQuery : IRequest<JsonResult>
    {
    }
}
