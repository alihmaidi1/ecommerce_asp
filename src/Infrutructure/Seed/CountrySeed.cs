
using ecommerce.Dto;
using ecommerce.infrutructure.Services.Interfaces;

namespace ecommerce.infrutructure.Seed
{
    public static class CountrySeed
    {



        public static async Task seedData(ApplicationDbContext context,IExternalRegionApi ExternalRegionApi)
        {

            if (!context.Countries.Any())
            {

                ExternalRegionDto<List<CountriesDto>> response = await ExternalRegionApi.GetAllCountry();
                var countries = response.data.Select(CountriesDto.ToCountryDto).ToList();
                context.Countries.BulkInsert(countries);
                context.SaveChanges();                                                
          
            }

        }

    }

}
