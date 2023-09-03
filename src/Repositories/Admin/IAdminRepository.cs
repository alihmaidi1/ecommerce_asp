using ecommerce.Domain.Entities.Identity;
using Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Admin
{
    public interface IAdminRepository: IgenericRepository<ecommerce.Domain.Entities.Identity.Admin>
    {


        public bool CheckEmailExists(string email);

    }
}
