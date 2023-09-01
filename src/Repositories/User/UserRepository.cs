<<<<<<< HEAD
﻿using ecommerce.infrutructure;
=======
﻿
using ecommerce.infrutructure;
>>>>>>> 90bac4133691690d5adc946ac38d3faf668d9f45
using Microsoft.AspNetCore.Identity;
using Repositories.Base.Concrete;
using ecommerce.infrutructure.ExtensionMethod;
using AccountEntity=ecommerce.Domain.Entities.Identity.Account;

namespace Repositories.User
{
    public class UserRepository : GenericRepository<ecommerce.Domain.Entities.Identity.User>, IUserRepository
    {
<<<<<<< HEAD
        public UserManager<AccountEntity> UserManager;
        public UserRepository(ApplicationDbContext DbContext,UserManager<AccountEntity> UserManager) : base(DbContext)
=======
        public UserManager<IdentityUser<Guid>> UserManager;
        public UserRepository(ApplicationDbContext DbContext,UserManager<IdentityUser<Guid>> UserManager) : base(DbContext)
>>>>>>> 90bac4133691690d5adc946ac38d3faf668d9f45
        {
        
            this.UserManager = UserManager;
        
        }

<<<<<<< HEAD
        public async Task<AccountEntity> GetUserByUserNameOrEmail(string UserNameOrEmail)
=======
        public async Task<IdentityUser<Guid>> GetUserByUserNameOrEmail(string UserNameOrEmail)
>>>>>>> 90bac4133691690d5adc946ac38d3faf668d9f45
        {

            return null;
            //var Account = await UserManager.FindByNameOrEmailAsync(UserNameOrEmail);

            //return Account;
            


        }



    }
}
