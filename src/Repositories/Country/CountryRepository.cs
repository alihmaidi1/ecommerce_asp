//using CountryEntity = ecommerce.Domain.Entities.Country.Country;
//using ecommerce.infrutructure;
//using Repositories.Base.Concrete;
//using ecommerce.Dto.Results.Admin.Country;
//using Repositories.Country.Store;
//using Microsoft.EntityFrameworkCore;
//using Nest;
//using ecommerce.infrutructure.ExtensionMethod;

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



//    }
//}
