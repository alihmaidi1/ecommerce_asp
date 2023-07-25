using ecommerce.admin.Features.Pages.Commands.Models;
using ecommerce.Domain.Enum;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.admin.Features.Pages.Commands.Validations
{
    public class AddPageValidation:AbstractValidator<AddPageCommand>
    {


        public AddPageValidation() {

            //NameRule();
            ContentRule();

        }

        public void NameRule()
        {

            RuleFor(x => x.Name).NotEmpty().NotNull();

        }

        public void ContentRule()
        {

            RuleFor(x => x.Content).NotEmpty().NotNull().Length(1);

        }


    }
}
