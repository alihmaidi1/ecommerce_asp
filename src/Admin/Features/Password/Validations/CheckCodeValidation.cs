using ecommerce.admin.Features.Password.Models;
using ecommerce.service.UserService;
using FluentValidation;
using Repositories.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.admin.Features.Password.Validations
{
    public class CheckCodeValidation:AbstractValidator<CheckCodeCommand>
    {

        public CheckCodeValidation(IAccountService AccountService) {

            RuleFor(x => x.Code)
                .NotEmpty()
                .NotEmpty()
                .Length(6)
                .Must(x =>AccountService.CheckCode(x).Result);
        }

    }
}
