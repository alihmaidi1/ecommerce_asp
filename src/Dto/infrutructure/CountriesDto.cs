using ecommerce.Domain.Entities.Country;

namespace ecommerce.Dto
{
    public class CountriesDto
    {



        public string Name { get; set; }
        public string Iso2 { get; set; }
        public double Lat { get; set; }


        public static Func<CountriesDto, Country> ToCountryDto = c => new Country
        {
            Name=c.Name,
            lat=c.Lat,
            Code=c.Iso2,


        };





    }




}
