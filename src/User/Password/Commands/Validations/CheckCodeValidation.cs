using ecommerce.models.Users.Password.Commands;
using ecommerce.service.UserService;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.user.Password.Commands.Validations
{
    public class CheckCodeValidation:AbstractValidator<CheckCodeCommand>
    {

        public CheckCodeValidation(IAccountService AccountService) {


            RuleFor(x => x.Code)
                .NotEmpty()
                .NotEmpty()
                .Length(6)
                .Must(x => AccountService.CheckCode(x).Result);
        }    
    }
}
