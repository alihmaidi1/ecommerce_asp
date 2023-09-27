using ecommerce_shared.OperationResult;
using ecommerce.models.Users.Country.Query;
using ecommerce.models.Users.Password.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Repositories.Country;

namespace ecommerce.user.Country.Query.Handler;

public class CountryHandler:OperationResult,
    IRequestHandler<GetAllCountryQuery, JsonResult>,
    IRequestHandler<GetActiveCitiesQuery, JsonResult>

{

    public ICountryRepository CountryRepository;
    
    public CountryHandler(ICountryRepository CountryRepository)
    {

        this.CountryRepository = CountryRepository;


    }
    
    public async Task<JsonResult> Handle(GetAllCountryQuery request, CancellationToken cancellationToken)
    {
        var Countries = CountryRepository.GetAllActiveCountries();

        return Success(Countries, "this is all countries");
    }

    public async Task<JsonResult> Handle(GetActiveCitiesQuery request, CancellationToken cancellationToken)
    {
        var Cities = CountryRepository.GetActiveCities(request.Id);
        return Success(Cities,"this is all active city for country");
    }
}