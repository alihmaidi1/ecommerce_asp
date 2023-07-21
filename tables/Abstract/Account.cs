using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ecommerce.Domain.Abstract
{
    public abstract class Account<T> : IdentityUser<Guid>
    {

    }
}
