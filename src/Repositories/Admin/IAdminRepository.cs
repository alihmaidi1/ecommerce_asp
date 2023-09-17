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
        public bool IsUniqueEmail(string email,Guid Id);

        public bool IsUniqueUserName(string userName);
        public bool IsUniqueUserName(string userName,Guid Id);


        public bool isExists(Guid Id);


        public bool BlockAdmin(Guid Id);

        public AdminEntity Get(Guid Id);
        public bool UnBlockAdmin(Guid Id);


        public Task<AdminEntity> Store(string Email,string UserName,string Password,Guid RoleId);
        public Task<AdminEntity> Update(Guid id,string Email, string UserName, string Password, Guid RoleId);

        public List<AdminEntity> GetAllForSuperAdmin();

    }
}
