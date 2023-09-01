using ecommerce.user.Features.Auth.Commands.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.user.Features.Auth.Commands.Validations
{
    public class LoginUserValidation: AbstractValidator<LoginUserCommand>
    {


        public LoginUserValidation() {

            ApplyUserNameOrEmailValidation();
            ApplyPasswordValiation();

        }


        public void ApplyUserNameOrEmailValidation()
        {

            RuleFor(x => x.UserNameOrEmail)
                .NotNull()
                .WithMessage("UserName Or Email CAnn not be null")
                .NotEmpty()
                .WithMessage("UserName Or Email CAnn not be nil")
                .Must(x=>x.Equals("ali"))
                ;
        }


        public void ApplyPasswordValiation()
        {

            RuleFor(x => x.Password)
                .NotEmpty()
                .NotNull();
        }


    }
}
