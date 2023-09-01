using ecommerce.admin.Features.Auth.Commands.Models;
using ecommerce.Domain.Enum;
using FluentValidation;
using Repositories.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.admin.Features.Auth.Commands.Validations
{
    public class LoginAdminValidation:AbstractValidator<LoginAdminCommand>
    {
        public LoginAdminValidation(IAccountRepository AccountRepository) {


            ApplyUserNameOrEmailValidation(AccountRepository);
            ApplyPasswordValidation();

        }

        public void ApplyUserNameOrEmailValidation(IAccountRepository AccountRepository)
        {

            RuleFor(x => x.UsernameOrEmail)
                .NotEmpty()
                .WithMessage("username or email Cannot be empty")
                .NotNull()
                .WithMessage("username or email cannot be null")
                .Must(x=>AccountRepository.CheckRoleUserNameOrEmail(x,RoleEnum.SuperAdmin))
                .WithMessage("This UserName Or Email Is Not Exists");



        }

        public void ApplyPasswordValidation()
        {

            RuleFor(x => x.Password)
                .NotEmpty()
                .NotNull();

        }
    }
}
