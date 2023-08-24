using ecommerce.user.Features.Auth.Commands.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.user.Features.Auth.Commands.Validations
{
    internal class LoginUserValidation: AbstractValidator<LoginUserCommand>
    {


        public LoginUserValidation() {

            ApplyUserNameOrEmailValidation();
            ApplyPasswordValiation();

        }


        public void ApplyUserNameOrEmailValidation()
        {

            RuleFor(x => x.UserNameOrEmail)
                .NotNull()
                .NotEmpty();
        }


        public void ApplyPasswordValiation()
        {

            RuleFor(x => x.Password)
                .NotEmpty()
                .NotNull();
        }


    }
}
