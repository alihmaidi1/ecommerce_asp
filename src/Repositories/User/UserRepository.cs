
using ecommerce.infrutructure;
using Microsoft.AspNetCore.Identity;
using Repositories.Base.Concrete;
using ecommerce.infrutructure.ExtensionMethod;
namespace Repositories.User
{
    public class UserRepository : GenericRepository<ecommerce.Domain.Entities.User>, IUserRepository
    {
        public UserManager<IdentityUser<Guid>> UserManager;
        public UserRepository(ApplicationDbContext DbContext,UserManager<IdentityUser<Guid>> UserManager) : base(DbContext)
        {
        
            this.UserManager = UserManager;
        
        }

        public async Task<IdentityUser<Guid>> GetUserByUserNameOrEmail(string UserNameOrEmail)
        {

            return null;
            //var Account = await UserManager.FindByNameOrEmailAsync(UserNameOrEmail);

            //return Account;
            


        }



    }
}
