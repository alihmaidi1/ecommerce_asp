using AccountEntity = ecommerce.Domain.Entities.Identity.Account;
using Repositories.Base.Concrete;
using ecommerce.infrutructure;
using ecommerce.Domain.Enum;

namespace Repositories.Account
{
    public class AccountRepository : GenericRepository<AccountEntity>, IAccountRepository
    {
     

        public AccountRepository(ApplicationDbContext DBContext) : base(DBContext)
        {


        }

        public bool CheckRoleUserNameOrEmail(string UserNameOrEmail, RoleEnum Role)
        {
            var exists=from account in DbContext.Accounts
                       where (
                                (account.Email == UserNameOrEmail ||
                                 account.UserName==UserNameOrEmail) &&
                                (from userrole in DbContext.UserRoles
                                 join role in DbContext.Roles
                                 on userrole.RoleId equals role.Id
                                 where (account.Id == userrole.UserId && role.Name.Equals(Role.ToString()))
                                 select role.Name)
                                 .Any()                                                              
                             )
                       select 1;

            return exists.Any();  

        }

        public bool CheckAccountCode(string Code, AccountEntity Account)
        {
                                    
            return Code.Equals(Account.Code);

        }


    }
}
