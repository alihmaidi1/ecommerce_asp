using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ecommerce.Domain.Entities;
using EntityFrameworkCore.EncryptColumn.Attribute;
using Microsoft.AspNetCore.Identity;

namespace ecommerce.Domain.Entities.Identity
{
    public class Account : IdentityUser<Guid>
    {

        public Account()
        {

            RefreshTokens = new HashSet<RefreshToken>();
        }
        public virtual User User { get; set; }
        public virtual Admin Admin { get; set; }

        [EncryptColumn]
        public string ? Code { get; set; }


        
        public virtual ICollection<RefreshToken>? RefreshTokens { get; set; }

    }
}
