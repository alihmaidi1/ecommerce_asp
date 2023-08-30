using CountryEntity=ecommerce.Domain.Entities.Country;
using ecommerce.infrutructure;
using Repositories.Base.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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


        public CountryEntity GetCountry(Guid id)
        {
         
            
            var Country=DbContext.Countries.SingleOrDefault(x=>x.Id==id);
            return Country;


            

        }


    }
}
