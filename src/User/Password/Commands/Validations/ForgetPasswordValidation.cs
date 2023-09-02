using ecommerce.Domain.Enum;
using ecommerce.models.Users.Password.Commands;
using FluentValidation;
using Repositories.Account;
using Repositories.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.user.Password.Commands.Validations
{
    public class ForgetPasswordValidation:AbstractValidator<ForgetPasswordCommand>
    {


        public ForgetPasswordValidation(IUserRepository UserRepository) {

            RuleFor(x => x.Email)
                .NotEmpty()
                .NotNull()        
                .Must(x => UserRepository.CheckEmailExists(x).Result);

        }

    }
}
