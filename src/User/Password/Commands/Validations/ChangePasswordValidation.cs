using ecommerce.models.Users.Password.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.user.Password.Commands.Validations
{
    public class ChangePasswordValidation:AbstractValidator<ChangePasswordCommand>
    {

        public ChangePasswordValidation() { 
        
            RuleFor(x=>x.password)
                .NotEmpty()
                .WithMessage("password can not be empty")
                .NotNull()
                .WithMessage("password can not be null");
        }   
    }
}
