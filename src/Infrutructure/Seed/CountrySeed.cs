
using ecommerce.Dto;
using ecommerce.infrutructure.Services.Interfaces;
using EFCore.BulkExtensions;

namespace ecommerce.infrutructure.Seed
{
    public static class CountrySeed
    {



        public static async Task seedData(ApplicationDbContext context,IExternalRegionApi ExternalRegionApi)
        {
            
            //if (!context.Countries.Any())
            //{

            //    ExternalRegionDto<List<CountriesDto>> response = await ExternalRegionApi.GetAllCountry();
            //    var countries = response.data.Select(CountriesDto.ToCountryDto).ToList();

            //    countries.Chunk(50).ToList().ForEach(country => {

            //        context.AddRange(country);
            //        context.SaveChanges();


            //    });
                




            //}

        }

    }

}
