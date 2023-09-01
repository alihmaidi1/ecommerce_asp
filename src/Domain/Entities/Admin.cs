using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tables.Base.Entity;

namespace ecommerce.Domain.Entities
{
    public class Admin : IdentityUser<Guid>
    {

        public Admin() {
        
            RefreshTokens=new HashSet<RefreshToken>();
        }

        public Guid Id { get; set; }
                
        public bool IsBlocked { get; set; }

        public virtual ICollection<RefreshToken>RefreshTokens { get; set; }

    }


}