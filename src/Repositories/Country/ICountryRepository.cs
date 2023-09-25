using CountryEntity= ecommerce.Domain.Entities.Country;
using ecommerce.Dto.Results.Admin.Country;
using Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ecommerce.Dto.Results.User.City.Query;

namespace Repositories.Country
{
    public interface ICountryRepository : Repositories.Base.IgenericRepository<ecommerce.Domain.Entities.Country>
    {



        public List<GetAllCountriesDto> GetAllCountries();
        
        public List<GetAllCountriesDto> GetAllActiveCountries();


        public List<OnlyCityDto> GetActiveCities(Guid CountryId);
        
        public GetCountryResponse GetCountry(Guid id);
        public bool IsExists(Guid Id);

        public bool IsActiveExists(Guid Id);

        public bool Active(Guid Id);


        public bool UnActive(Guid Id);
        


    }
}
