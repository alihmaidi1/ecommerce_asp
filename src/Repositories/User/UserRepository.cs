using ecommerce.Domain.Abstract;
using ecommerce.Domain.Entities;
using ecommerce.infrutructure;
using ecommerce_shared.Repository.Concrete;
using Microsoft.AspNetCore.Identity;
using Repositories.ExtensionMethod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
