using ecommerce.admin.Features.Password.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.admin.Features.Password.Validations
{
    public class CheckCodeValidation:AbstractValidator<CheckCodeCommand>
    {

        public CheckCodeValidation() {

            RuleFor(x => x.Code)
                .NotEmpty()
                .NotEmpty()
                .Length(6);
        }

    }
}
