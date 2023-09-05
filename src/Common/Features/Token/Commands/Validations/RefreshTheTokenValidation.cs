using Common.Features.Token.Commands.Models;
using FluentValidation;
using Repositories.RefreshToken;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Features.Token.Commands.Validations
{
    public class RefreshTheTokenValidation:AbstractValidator<RefreshTheTokenCommand>
    {


        public RefreshTheTokenValidation(IRefreshTokenRepository RefreshTokenRepository) {

            RuleFor(x => x.RefreshToken)
                .NotEmpty()
                .WithMessage("refresh token can not be empty")
                .NotNull()
                .WithMessage("refresh token can not be null")
                .Must(x=> RefreshTokenRepository.IsValid(x))
                .WithMessage("this refresh token is not valid");
        
        }  




    }
}
