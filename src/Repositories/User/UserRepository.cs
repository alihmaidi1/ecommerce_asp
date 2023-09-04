using ecommerce.infrutructure;
using Microsoft.AspNetCore.Identity;
using Repositories.Base.Concrete;
using ecommerce.infrutructure.ExtensionMethod;
using AccountEntity = ecommerce.Domain.Entities.Identity.Account;
using UserEntity = ecommerce.Domain.Entities.Identity.User;

using ecommerce_shared.Enums;
using Microsoft.EntityFrameworkCore;
using ecommerce_shared.Helper;
using Repositories.Account;
using ecommerce_shared.Services.Authentication.ResponseAuth;

namespace Repositories.User
{
    public class UserRepository : GenericRepository<UserEntity>, IUserRepository
    {
        public UserManager<AccountEntity> UserManager;

        public IAccountRepository AccountRepository;
        public UserRepository(IAccountRepository AccountRepository,ApplicationDbContext DbContext,UserManager<AccountEntity> UserManager) : base(DbContext)
        {
        
            this.AccountRepository = AccountRepository; 
            this.UserManager = UserManager;
        
        }

        //public async Task<AccountEntity> GetUserByUserNameOrEmail(string UserNameOrEmail)
        //{

        //    var Account = await UserManager.FindByNameOrEmailAsync(UserNameOrEmail);

        //    return Account;
            


        //}

        public async Task<bool> CheckEmailExists(string Email)
        {
            return DbContext.Accounts.OfType<UserEntity>().Any(x=>x.Email.Equals(Email)&&x.ProviderType==ProviderAuthentication.Local);
        }


        public async Task<UserEntity> GetUserByProviderId(string Id,ProviderAuthentication provider)
        {

            return this.DbContext.Users.FirstOrDefault(x => x.ProviderId.Equals(Id)&&x.ProviderType== provider);
            
        }


        public async Task<UserEntity> CreateExternalUser(Response ApiResponse, ProviderAuthentication provider)
        {
            AccountEntity Account=await AccountRepository.CreateExternal(ApiResponse,provider);
            return Account as UserEntity;

        }


    }
}
