using ecommerce.Domain.Abstract;
using ecommerce.Domain.Entities;
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

        public Task<bool> CreateAccountAsync(Account Account,string password);
    }
}
