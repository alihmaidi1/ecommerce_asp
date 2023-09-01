<<<<<<< HEAD
﻿using ecommerce.Domain.Entities.Identity;
=======
﻿
using Microsoft.AspNetCore.Identity;
>>>>>>> 90bac4133691690d5adc946ac38d3faf668d9f45
using Repositories.Base;

namespace Repositories.User
{
    public interface IUserRepository: IgenericRepository<ecommerce.Domain.Entities.Identity.User>
    {

<<<<<<< HEAD
        public  Task<ecommerce.Domain.Entities.Identity.Account> GetUserByUserNameOrEmail(string UserNameOrEmail);
=======
        public  Task<IdentityUser<Guid>> GetUserByUserNameOrEmail(string UserNameOrEmail);
>>>>>>> 90bac4133691690d5adc946ac38d3faf668d9f45

    }
}
