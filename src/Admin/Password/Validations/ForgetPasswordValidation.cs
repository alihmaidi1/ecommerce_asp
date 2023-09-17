using ecommerce.admin.Password.Models;
using ecommerce.Domain.Enum;
using FluentValidation;
using Repositories.Account;
using Repositories.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.admin.Password.Validations
{
    public class ForgetPasswordValidation : AbstractValidator<ForgetPasswordCommand>
    {



        public ForgetPasswordValidation(IAdminRepository AdminRepository)
        {


            RuleFor(x => x.Email)
                .NotEmpty()
                .NotNull()
                .Must(x => AdminRepository.CheckEmailExists(x));

        }

    }
}
