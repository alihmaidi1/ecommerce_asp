using Common.Features.Token.Commands.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Features.Token.Commands.Validations
{
    public class RefreshTheTokenValidation:AbstractValidator<RefreshTheTokenCommand>
    {


        public RefreshTheTokenValidation() {

            RuleFor(x => x.RefreshToken)
                .NotEmpty()
                .NotNull();
        
        }  




    }
}
