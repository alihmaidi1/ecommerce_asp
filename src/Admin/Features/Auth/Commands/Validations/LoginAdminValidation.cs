using ecommerce.admin.Features.Auth.Commands.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.admin.Features.Auth.Commands.Validations
{
    public class LoginAdminValidation:AbstractValidator<LoginAdminCommand>
    {
        public LoginAdminValidation() {


            ApplyUserNameOrEmailValidation();
            ApplyPasswordValidation();

        }

        public void ApplyUserNameOrEmailValidation()
        {

            RuleFor(x => x.UsernameOrEmail)
                .NotEmpty()
                .WithMessage("username or email Cannot be empty")
                .NotNull()
                .WithMessage("username or email cannot be null");



        }

        public void ApplyPasswordValidation()
        {

            RuleFor(x => x.Password)
                .NotEmpty()
                .NotNull();

        }
    }
}
