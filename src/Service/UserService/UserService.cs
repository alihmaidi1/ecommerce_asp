using AutoMapper;
using ecommerce.Domain.Entities.Identity;
using ecommerce.infrutructure;
using ecommerce.models.Users.Auth.Commands;
using ecommerce_shared.Helper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.service.UserService
{
    public class UserService:IUserService
    {

        public readonly IMapper mapper;
        public ApplicationDbContext Context;
        public UserManager<Account> UserManager;

        public readonly IAccountService AccountService;
        public UserService(UserManager<Account> UserManager,IMapper mapper, IAccountService AccountService, ApplicationDbContext Context)
        {

            this.mapper = mapper;
            this.Context = Context;
            this.UserManager = UserManager;
            this.AccountService = AccountService;

        }

        public async Task<User> CreateUser(AddUserCommand request)
        {
            var Account = mapper.Map<Account>(request);
            await AccountService.CreateAccountAsync(Account, request.Password);
            var User = Context.Users.CreateProxy();
            User=mapper.Map(request, User, opts => opts.AfterMap((src, desc) => desc.AccountId = Account.Id));
            Context.Users.Add(User);
            Context.SaveChanges();
            return User;
        }

        public async Task<User> ConfirmAccount(string Email, string Code)
        {
            var Account = await UserManager.FindByEmailAsync(Email);
            Account.EmailConfirmed.ThrowIfTrue("Your Email Is Already Confirmed");
            Account.ConfirmCode.Equals(Code).ThrowIfFalse("Your Code Is Not Correct");
            Account.EmailConfirmed = true;
            await UserManager.UpdateAsync(Account);
            return Account.User;

        }

        public async Task<User> SigninUser(string UserNameOrEmail,string Passowrd)
        {


            Account Account = await AccountService.SignInAccountAsync(UserNameOrEmail, Passowrd);
            Account.EmailConfirmed.ThrowIfFalse("Your Email Is Not Confirmed");
            return Account.User;
        }




    }
}
