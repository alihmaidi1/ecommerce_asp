using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.models.SuperAdmin.Admin.Query
{
    public class GetAllAdminQuery:IRequest<JsonResult>
    {
    }
}
