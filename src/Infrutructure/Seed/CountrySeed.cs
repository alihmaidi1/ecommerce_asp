
using ecommerce.Domain.Entities;
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

<<<<<<< HEAD
                List<Country> Countries = new List<Country>();
                Countries.Add(new Country{ Name = "Syria",Code = "sy",lat = 4.6,lon = 6.5,Status = true});
                    
                // ExternalRegionDto<List<CountriesDto>> response = await ExternalRegionApi.GetAllCountry();
                // var countries = response.data.Select(CountriesDto.ToCountryDto).ToList();
                 
                 context.AddRange(Countries);
                 context.SaveChanges();
                 // countries.Chunk(50).ToList().ForEach(country => {
                 //
                 //     context.AddRange(country);
                 //     context.SaveChanges();
                 //
                 //
                 // });
                 //
=======
            //    ExternalRegionDto<List<CountriesDto>> response = await ExternalRegionApi.GetAllCountry();
            //    var countries = response.data.Select(CountriesDto.ToCountryDto).ToList();

            //    countries.Chunk(50).ToList().ForEach(country => {

            //        context.AddRange(country);
            //        context.SaveChanges();


            //    });
                
>>>>>>> 07266b15958bf96eea3c784909c9f5bee4e25ecf




            //}

        }

    }

}
