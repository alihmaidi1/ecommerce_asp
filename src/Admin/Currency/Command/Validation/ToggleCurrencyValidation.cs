using ecommerce.models.SuperAdmin.Currency;
using FluentValidation;
using Repositories.Currency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.superadmin.Currency.Command.Validation
{
    public class ToggleCurrencyValidation:AbstractValidator<ToggleCurrencyCommand>
    {

        public ToggleCurrencyValidation(ICurrencyRepository CurrencyRepository) { 
        
            RuleFor(x=>x.Id)
                .NotEmpty()
                .NotNull()
                .Must(id=>CurrencyRepository.IsExists(id));
        }

    }
}
