using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Role
{
    public interface IRoleRepository
    {

        public  List<IdentityRole<Guid>> GetAllRole();
    }
}
