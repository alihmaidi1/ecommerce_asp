using ecommerce.admin.Features.Password.Models;
using ecommerce.Domain.Enum;
using FluentValidation;
using Repositories.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.admin.Features.Password.Validations
{
    public class ForgetPasswordValidation:AbstractValidator<ForgetPasswordCommand>
    {



        public ForgetPasswordValidation(IAccountRepository accountRepository) { 
        
                
            RuleFor(x=>x.Email)
                .NotEmpty()
                .NotNull()
                .Must(x=> accountRepository.CheckRoleUserNameOrEmail(x,RoleEnum.SuperAdmin));
        
        }

    }
}
