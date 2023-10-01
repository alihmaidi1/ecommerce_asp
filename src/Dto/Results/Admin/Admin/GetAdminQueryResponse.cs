using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.Dto.Results.Admin.Admin
{
    public class GetAdminQueryResponse
    {

        public Guid Id { get; set; }
        public string UserName { get; set; }

        public string Email { get; set; }
        public bool IsBlocked { get; set; }

    }
}
