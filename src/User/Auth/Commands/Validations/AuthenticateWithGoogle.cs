using ecommerce.models.Users.Auth.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.user.Auth.Commands.Validations
{
    public class AuthenticateWithGoogle:AbstractValidator<AuthenticateWithGoogleCommand>
    {

        public AuthenticateWithGoogle() { 
        
            RuleFor(x=>x.Token)
                .NotEmpty()
                .NotNull();
        }
    }
}
