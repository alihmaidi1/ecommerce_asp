using ecommerce.admin.Country.Queries.Models;
using FluentValidation;
using Repositories.Country;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.admin.Country.Queries.Validations
{
    public class GetCountryValidation : AbstractValidator<GetCountryQuery>
    {

        public GetCountryValidation(ICountryRepository CountryRepository)
        {

            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("country id should not be empty")
                .NotNull()
                .WithMessage("country id should not be null")
                .Must(x => CountryRepository.IsExists(x))
                .WithMessage("country is not exists");

        }


    }
}
