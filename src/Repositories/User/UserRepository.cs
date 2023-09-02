using ecommerce.infrutructure;
using Microsoft.AspNetCore.Identity;
using Repositories.Base.Concrete;
using ecommerce.infrutructure.ExtensionMethod;
using AccountEntity=ecommerce.Domain.Entities.Identity.Account;

namespace Repositories.User
{
    public class UserRepository : GenericRepository<ecommerce.Domain.Entities.Identity.User>, IUserRepository
    {
        public UserManager<AccountEntity> UserManager;
        public UserRepository(ApplicationDbContext DbContext,UserManager<AccountEntity> UserManager) : base(DbContext)
        {
        
            this.UserManager = UserManager;
        
        }

        public async Task<AccountEntity> GetUserByUserNameOrEmail(string UserNameOrEmail)
        {

            var Account = await UserManager.FindByNameOrEmailAsync(UserNameOrEmail);

            return Account;
            


        }

        public async Task<bool> CheckEmailExists(string Email)
        {
            var Account=await UserManager.FindByEmailAsync(Email);
            return DbContext.Users.Any(x => x.AccountId == Account.Id);
        }



    }
}
