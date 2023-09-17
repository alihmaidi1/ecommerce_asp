using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.Dto.Results.Admin.Admin
{
    public class GetAllAdminQuery
    {

        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }

        public bool EmailConfirmed { get; set; }
        public bool isBlocked { get; set; }

        




    }
}
