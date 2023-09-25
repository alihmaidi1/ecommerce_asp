using ecommerce.Domain.Entities;
using ecommerce.Domain.Entities.Identity;
using ecommerce.Dto.Base;
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

        public Task<bool> ResetCode(Account Account);
        public Task<bool> SendConfirmCode(Guid id ,string email);

        public Task<Account> CreateAccountAsync(Account Account,string password);
        public Task<bool> CheckCode(string Code);

    }
}
