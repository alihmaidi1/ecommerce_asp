using ecommerce.Domain.Abstract;
using ecommerce.infrutructure;
using Microsoft.AspNetCore.Identity;
using Repositories.Base.Concrete;
using ecommerce.infrutructure.ExtensionMethod;
namespace Repositories.User
{
    public class UserRepository : GenericRepository<ecommerce.Domain.Entities.User>, IUserRepository
    {
        public UserManager<Account> UserManager;
        public UserRepository(ApplicationDbContext DbContext,UserManager<Account> UserManager) : base(DbContext)
        {
        
            this.UserManager = UserManager;
        
        }

        public async Task<Account> GetUserByUserNameOrEmail(string UserNameOrEmail)
        {

            var Account = await UserManager.FindByNameOrEmailAsync(UserNameOrEmail);

            return Account;
            


        }



    }
}
