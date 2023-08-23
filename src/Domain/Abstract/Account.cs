using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ecommerce.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace ecommerce.Domain.Abstract
{
    public class Account : IdentityUser<Guid>
    {

        public Account() { 
        
            RefreshTokens=new HashSet<RefreshToken>();    
        }
        public virtual User User { get; set; }
        public virtual Admin Admin{ get; set; }


        public virtual ICollection<RefreshToken>? RefreshTokens{ get; set; }    

    }
}
