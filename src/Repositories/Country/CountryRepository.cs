<<<<<<< HEAD
﻿using CountryEntity=ecommerce.Domain.Entities.Country;
using ecommerce.infrutructure;
using Repositories.Base.Concrete;
using ecommerce.Dto.Results.Admin.Country;
using Repositories.Country.Store;
using Microsoft.EntityFrameworkCore;
using ecommerce.Domain.Entities;
using ecommerce.Dto.Results.User.City.Query;
using Nest;
using ecommerce.infrutructure.ExtensionMethod;
=======
﻿//using CountryEntity = ecommerce.Domain.Entities.Country.Country;
//using ecommerce.infrutructure;
//using Repositories.Base.Concrete;
//using ecommerce.Dto.Results.Admin.Country;
//using Repositories.Country.Store;
//using Microsoft.EntityFrameworkCore;
//using Nest;
//using ecommerce.infrutructure.ExtensionMethod;
>>>>>>> 07266b15958bf96eea3c784909c9f5bee4e25ecf

//namespace Repositories.Country
//{
//    public class CountryRepository : GenericRepository<CountryEntity>, ICountryRepository
//    {
//        public CountryRepository(ApplicationDbContext DbContext) : base(DbContext)
//        {
//        }


//        public List<GetAllCountriesDto> GetAllCountries()
//        {

//            var Countries = DbContext.Countries.Select(CountryStore.Query.ToGetAllCountryDto).ToList();

//            return Countries;
//        }

        public List<GetAllCountriesDto> GetAllActiveCountries()
        {
            
            var Countries = DbContext.Countries.Select(CountryStore.Query.ToGetAllCountryDto).Where(x=>x.Status==true).ToList();

            return Countries;
            
            
        }


//        public GetCountryResponse GetCountry(Guid id)
//        {
         
            
//            var Country=DbContext
//                .Countries
//                .Select(CountryStore.Query.ToGetCountryDto)
//                .SingleOrDefault(x=>x.Id==id);
//            return Country;


            

//        }

//        public bool IsExists(Guid Id)
//        {

//            return DbContext.Countries.Any(x=>x.Id==Id);

//        }



//        public bool Active(Guid Id)
//        {

//            DbContext.Countries
//                .Where(x => x.Id == Id)
//                .ExecuteUpdate(setter => setter.SetProperty(p => p.Status, true));

//            return true;


//        }


//        public bool UnActive(Guid Id)
//        {

//            var Country=DbContext.Countries
//                .Select(x=>new {
//                    Id=x.Id,
//                    cities=x.Cities.Select(c=>c.Id)
                
//                }).First(x=>x.Id==Id);


//            DbContext.Countries
//                .Where(x => x.Id == Id)
//                .ExecuteUpdate(setter => setter.SetProperty(p => p.Status, false));
//            List<Guid> CitiesIds=Country.cities.ToList();
//            DbContext.Countries
//                .Where(x => CitiesIds.Any(c => c == x.Id))
//                .ExecuteUpdate(setter => setter.SetProperty(p => p.Status, false));


//            return true;

//        }

        public List<OnlyCityDto> GetActiveCities(Guid CountryId)
        {

            return DbContext.Cities.Select(x => new OnlyCityDto { Id = x.Id,status = x.status, Delivery_Price = x.Delivery_Price, Name = x.Name }).Where(x=>x.status==true).ToList();

            

        }

        public bool IsActiveExists(Guid Id)
        {
            return DbContext.Countries.Any(x => x.Id == Id && x.Status == true);



        }



//    }
//}
