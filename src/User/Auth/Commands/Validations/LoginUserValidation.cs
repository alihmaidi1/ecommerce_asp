using ecommerce.models.Users.Auth.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.user.Auth.Commands.Validations
{
    public class LoginUserValidation : AbstractValidator<LoginUserCommand>
    {


        public LoginUserValidation()
        {

            ApplyUserNameOrEmailValidation();
            ApplyPasswordValiation();

        }


        public void ApplyUserNameOrEmailValidation()
        {

            RuleFor(x => x.UserNameOrEmail)
                .NotNull()
                .WithMessage("UserName Or Email Can not be null")
                .NotEmpty()
                .WithMessage("UserName Or Email Can not be empty")
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
