//using CountryEntity = ecommerce.Domain.Entities.Country.Country.Country.Country.Country;
//using ecommerce_shared.OperationResult;
//using MediatR;
//using Microsoft.AspNetCore.Mvc;
//using Repositories.Country;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using ecommerce.Dto.Results.Admin.Country;
//using ecommerce.admin.Country.Queries.Models;

//namespace ecommerce.admin.Country.Queries.Handlers
//{
//    public class CountryHandlers : OperationResult,
//        IRequestHandler<GetAllCountriesQuery, JsonResult>,
//        IRequestHandler<GetCountryQuery, JsonResult>

//    {


//        private ICountryRepository CountryRepository;

//        public CountryHandlers(ICountryRepository CountryRepository)
//        {

//            this.CountryRepository = CountryRepository;

//        }

//        public async Task<JsonResult> Handle(GetAllCountriesQuery request, CancellationToken cancellationToken)
//        {

//            List<GetAllCountriesDto> Countries = CountryRepository.GetAllCountries();
//            return Success(Countries, "This is All Your Countries");

//        }

//        public async Task<JsonResult> Handle(GetCountryQuery request, CancellationToken cancellationToken)
//        {

//            var Country = CountryRepository.GetCountry(request.Id);
//            return Success(Country, "This is The Country");
//        }
//    }
//}
