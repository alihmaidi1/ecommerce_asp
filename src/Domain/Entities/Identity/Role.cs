using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.Domain.Entities.Identity
{
    public class Role : IdentityRole<Guid>
    {


        public Role()
        {


            //Accounts = new HashSet<Account>();
            //UserRoles = new HashSet<UserRole>();
        }

        //public virtual ICollection<UserRole> UserRoles { get; set; }
        //public virtual ICollection<Account> Accounts { get; set; }


    }
}
