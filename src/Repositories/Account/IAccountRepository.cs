using AccountEntity = ecommerce.Domain.Entities.Identity.Account;
using Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ecommerce.Domain.Enum;

namespace Repositories.Account
{
    public interface IAccountRepository:IgenericRepository<AccountEntity>
    {



        public bool CheckRoleUserNameOrEmail(string UserNameOrEmail,RoleEnum Role);

        public bool CheckAccountCode(string Code, AccountEntity Account);
        public bool CheckConfirmCode(string Code, AccountEntity Account);


    }
}
