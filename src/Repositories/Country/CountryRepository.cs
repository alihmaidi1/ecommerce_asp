using CountryEntity=ecommerce.Domain.Entities.Country;
using ecommerce.infrutructure;
using Repositories.Base.Concrete;
using ecommerce.Dto.Results.Admin.Country;
using Repositories.Country.Store;

namespace Repositories.Country
{
    public class CountryRepository : GenericRepository<CountryEntity>, ICountryRepository
    {
        public CountryRepository(ApplicationDbContext DbContext) : base(DbContext)
        {
        }


        public List<GetAllCountriesDto> GetAllCountries()
        {

            var Countries = DbContext.Countries.Select(CountryStore.Query.ToGetAllCountryDto).ToList();

            return Countries;
        }


        public GetCountryResponse GetCountry(Guid id)
        {
         
            
            var Country=DbContext
                .Countries
                .Select(CountryStore.Query.ToGetCountryDto)
                .SingleOrDefault(x=>x.Id==id);
            return Country;


            

        }

        public bool IsExists(Guid Id)
        {

            return DbContext.Countries.Any(x=>x.Id==Id);

        }


    }
}
