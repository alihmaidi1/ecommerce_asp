using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AdminEntity=ecommerce.Domain.Entities.Identity.Admin;

namespace ecommerce.Dto.Results.Admin.Role
{
    public class GetRoleResponse
    {

        public Guid Id { get; set; }
        

        public string Name { get; set; }

        public List<string> Permissions { get; set; }
        public List<AdminEntity> Admins { get; set; }

    }
}
