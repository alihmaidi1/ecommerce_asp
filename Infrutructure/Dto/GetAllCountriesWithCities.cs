using ecommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.infrutructure.Dto
{
    public class GetAllCountriesWithCities
    {

        public string Country { get; set;}

        public List<string> cities { get; set;}


        public  Func<GetAllCountriesWithCities, List<Country>, List<City>> ToListOfCities = ToListOfcitiesFunc;

        public static List<City> ToListOfcitiesFunc(GetAllCountriesWithCities CountriesWithCities, List<Country> Countries)
        {
            Country Country = Countries.SingleOrDefault(c => c.Name== CountriesWithCities.Country);

            if(Country == null )
            {

                return new List<City>();
            }
            return CountriesWithCities.cities.Select(c => new City
            {
                Name=c,
                CountryId=Country.Id,

            }).ToList();    
        }

    }
}
