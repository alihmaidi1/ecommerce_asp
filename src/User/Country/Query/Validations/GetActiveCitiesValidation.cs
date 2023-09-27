using ecommerce.models.Users.Country.Query;
using FluentValidation;
using Repositories.Country;

namespace ecommerce.user.Country.Query.Validations;

public class GetActiveCitiesValidation:AbstractValidator<GetActiveCitiesQuery>
{

    public GetActiveCitiesValidation(ICountryRepository countryRepository)
    {

        RuleFor(x => x.Id)
            .NotEmpty()
            .NotNull()
            .Must(x=>countryRepository.IsActiveExists(x));

    }
    
}