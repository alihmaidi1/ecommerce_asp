
using ecommerce.Domain.Entities;
using Microsoft.AspNetCore.Identity;
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

        public Task<bool> CreateAccountAsync(IdentityUser<Guid> Account,string password);
    }
}
