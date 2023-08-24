using ecommerce.user.Features.Auth.Commands.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.user.Features.Auth.Commands.Validations
{
    public class LogoutUserValidation:AbstractValidator<LogoutUserCommand>
    {


        public LogoutUserValidation() { 
        
            RuleFor(x=>x.Token)
                .NotEmpty()
                .NotNull();

        }

    }
}
