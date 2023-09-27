//using CountryEntity = ecommerce.Domain.Entities.Country.Country;
//using ecommerce.Dto.Results.Admin.Country;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Linq.Expressions;
//using System.Text;
//using System.Threading.Tasks;
//using Repositories.City.CityStore;
//using ecommerce.Dto.Results.Admin.City;
//using ecommerce.Dto.Results.User.City.Query;

//namespace Repositories.Country.Store
//{
//    public static class CountryStore
//    {

//        public static class Query
//        {

<<<<<<< HEAD
//            public static Expression<Func<CountryEntity, GetAllCountriesDto>> ToGetAllCountryDto => c => new GetAllCountriesDto
//            {
//                Id = c.Id,
//                Code = c.Code,
//                lat = c.lat,
//                Name = c.Name,
//                Status = c.Status,
=======
            public static Expression<Func<CountryEntity, GetAllCountriesDto>> ToGetAllCountryDto => c => new GetAllCountriesDto
            {
                Id = c.Id,
                Code = c.Code,
                lat = c.lat,
                lon=c.lon,
                
                Name = c.Name,
                Status = c.Status,
>>>>>>> ed

//            };

//            public static Expression<Func<CountryEntity, GetCountryResponse>> ToGetCountryDto => c => new GetCountryResponse
//            {
//                Id = c.Id,
//                Code = c.Code,
//                lat = c.lat,
//                Name = c.Name,
//                Status = c.Status,
//                Cities = c.Cities.AsQueryable().Select(CityStoreService.Query.ToCountryWithCityResponse).ToList(),
                
//            };

//        }

//    }
//}
