<<<<<<< HEAD
﻿using ecommerce.Domain.Entities;
using ecommerce.Domain.Entities.Identity;
=======
﻿
using ecommerce.Domain.Entities;
using Microsoft.AspNetCore.Identity;
>>>>>>> 90bac4133691690d5adc946ac38d3faf668d9f45
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.service.UserService
{
    public interface IAccountService
    {

        public Task<IdentityUser<Guid>> SignInAccountAsync(string UserNameOrEmail,string password);

<<<<<<< HEAD
        public Task<bool> Logout(string Token);

        public Task<bool> SendEmail(string Email);

        public Task<bool> CreateAccountAsync(Account Account,string password);
=======
        public Task<bool> CreateAccountAsync(IdentityUser<Guid> Account,string password);
>>>>>>> 90bac4133691690d5adc946ac38d3faf668d9f45
    }
}
