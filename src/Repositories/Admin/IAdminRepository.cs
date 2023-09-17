using AdminEntity=ecommerce.Domain.Entities.Identity.Admin;
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
        public bool IsUniqueUserName(string userName);

        public Task<AdminEntity> Store(string Email,string UserName,string Password,Guid RoleId);

        public List<AdminEntity> GetAllForSuperAdmin();

    }
}
