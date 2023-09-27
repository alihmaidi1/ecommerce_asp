using ecommerce.Domain.Entities.City;
using ecommerce.Domain.Entities.Country;
using ecommerce.Dto;
using ecommerce.infrutructure.Services.Interfaces;
using EFCore.BulkExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.infrutructure.Seed
{
    public static class Cityseed
    {

        public static async Task seedData(ApplicationDbContext context, IExternalRegionApi ExternalRegionApi)
        {


            //if (!context.Cities.Any())
            //{


<<<<<<< HEAD
            //    ExternalRegionDto<List<GetAllCountriesWithCities>> response = await ExternalRegionApi.GetAllCountriesWithCities();
            //    List<Country> Countries = context.Countries.Select(Country.SelectIDAndName).ToList();
            //    List<City> data = response.data.SelectMany(x => x.ToListOfCities(x, Countries)).ToList();
                


            //    data.Chunk(50).ToList().ForEach(city =>
            //    {
            //        context.AddRange(city);
            //        context.SaveChanges();
                
            //    });
                
=======
                var Country=context.Countries.First(x=>x.Name=="Syria");
                List<City> Cities = new List<City>();
                Cities.Add(new City{Name = "Idlib",CountryId = Country.Id});

                Cities.Add(new City{Name = "Aleepo",CountryId = Country.Id,status = true});
                Cities.Add(new City{Name = "Hama",CountryId = Country.Id,status = true});
                Cities.Add(new City{Name = "Homs",CountryId = Country.Id,status = true});
                Cities.Add(new City{Name = "Damascus",CountryId = Country.Id,status = true});
                Cities.Add(new City{Name = "Daraa",CountryId = Country.Id,status = true});
                Cities.Add(new City{Name = "Deir ez-zor",CountryId = Country.Id,status = true});
                Cities.Add(new City{Name = "Al-Hasakah",CountryId = Country.Id,status = true});

                Cities.Add(new City{Name = "Al-Raqqah",CountryId = Country.Id,status = true});
                Cities.Add(new City{Name = "Latakia",CountryId = Country.Id,status = true});
                Cities.Add(new City{Name = "Tartus",CountryId = Country.Id,status = true});

                Cities.Add(new City{Name = "Al-Suwayda",CountryId = Country.Id,status = true});

                Cities.Add(new City{Name = "Quneitra",CountryId = Country.Id,status = true});

                context.AddRange(Cities);
                context.SaveChanges();
                // ExternalRegionDto<List<GetAllCountriesWithCities>> response = await ExternalRegionApi.GetAllCountriesWithCities();
                // List<Country> Countries = context.Countries.Select(Country.SelectIDAndName).ToList();
                // List<City> data = response.data.SelectMany(x => x.ToListOfCities(x, Countries)).ToList();


                //
                // data.Chunk(50).ToList().ForEach(city =>
                // {
                //     context.AddRange(city);
                //     context.SaveChanges();
                //
                // });
                //
>>>>>>> ed


            //}


        }

    }
}
