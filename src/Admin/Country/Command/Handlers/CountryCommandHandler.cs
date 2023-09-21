using ecommerce.admin.Country.Queries.Models;
using ecommerce.models.SuperAdmin.Country;
using ecommerce_shared.OperationResult;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Repositories.Country;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.superadmin.Country.Command.Handlers
{
    public class CountryCommandHandler : OperationResult,
        IRequestHandler<ActiveCountryCommand, JsonResult>,
        IRequestHandler<UnActiveCountryCommand, JsonResult>

    {


        public ICountryRepository CountryRepository;

        public CountryCommandHandler(ICountryRepository countryRepository)
        {

            this.CountryRepository = countryRepository; 

        }


        public async Task<JsonResult> Handle(ActiveCountryCommand request, CancellationToken cancellationToken)
        {

            var IsActive = CountryRepository.Active(request.Id);
            return Success(IsActive, "the country is Active successfully");


        }

        public async Task<JsonResult> Handle(UnActiveCountryCommand request, CancellationToken cancellationToken)
        {

            var IsUnActive= CountryRepository.UnActive(request.Id);
            return Success(IsUnActive, "The Country Was UnActive Successfully");
        }
    }
}
