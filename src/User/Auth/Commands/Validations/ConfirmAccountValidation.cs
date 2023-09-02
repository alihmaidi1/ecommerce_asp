using ecommerce.Domain.Entities.Identity;
using ecommerce.models.Users.Auth.Commands;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.user.Auth.Commands.Validations
{
    public class ConfirmAccountValidation : AbstractValidator<ConfirmAccountCommand>
    {

        public ConfirmAccountValidation()
        {

            ApplyEmailValidation();
            ApplyCodeValidation();

        }

        public void ApplyCodeValidation()
        {

            RuleFor(x => x.Code)
                .NotEmpty()
                .NotNull();
        }


        public void ApplyEmailValidation()
        {

            RuleFor(x => x.Email)
                .NotEmpty()
                .NotNull();

        }
    }
}
