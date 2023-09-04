using ecommerce.models.Users.Auth.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.user.Auth.Commands.Validations
{
    public class AuthenticateWithGithub:AbstractValidator<AuthenticateWithGithubCommand>
    {


        public AuthenticateWithGithub() { 
        

            RuleFor(x=>x.Token).NotEmpty().NotNull();
        } 
    }
}
