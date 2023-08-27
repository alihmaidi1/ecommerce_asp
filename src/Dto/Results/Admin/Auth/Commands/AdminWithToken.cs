using ecommerce.Dto.Base;
using ecommerce.Dto.Results.User.City.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.Dto.Results.Admin.Auth.Commands
{
    public class AdminWithToken
    {
        public Guid Id { get; set; }


        public string UserName { get; set; }

        public string Email { get; set; }
        
        
        public bool IsBlocked { get; set; }


        public TokenDto TokenInfo { get; set; }


    }
}
