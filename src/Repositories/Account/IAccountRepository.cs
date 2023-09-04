using AccountEntity = ecommerce.Domain.Entities.Identity.Account;
using Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ecommerce.Domain.Enum;
using ecommerce_shared.Enums;
using ecommerce_shared.Services.Authentication.ResponseAuth;

namespace Repositories.Account
{
    public interface IAccountRepository:IgenericRepository<AccountEntity>
    {



        public bool CheckRoleUserName(string UserName,RoleEnum Role);
        public bool CheckRoleEmail(string UserName, RoleEnum Role);

        public bool CheckAccountCode(string Code, AccountEntity Account);
        public bool CheckConfirmCode(string Code, AccountEntity Account);


        public Task<AccountEntity> CreateExternal(Response ApiResponse,ProviderAuthentication Provider);


    }
}
