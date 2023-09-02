using ecommerce.Domain.Entities;
using ecommerce.Domain.Entities.Identity;
using ecommerce.models.Users.Auth.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.service.UserService
{
    public interface IUserService
    {

        public Task<User> CreateUser(AddUserCommand request);

        public Task<User> ConfirmAccount(string Email,string Code);

        public Task<User> SigninUser(string UserNameOrEmail, string Passowrd);

    }
}
