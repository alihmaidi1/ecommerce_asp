using ecommerce.Domain.Entities;
using ecommerce.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.service.UserService
{
    public interface IAccountService
    {

        public Task<Account> SignInAccountAsync(string UserNameOrEmail,string password);

        public Task<bool> Logout(string Token);

        public Task<bool> SendEmail(string Email);

        public Task<bool> CreateAccountAsync(Account Account,string password);
    }
}
