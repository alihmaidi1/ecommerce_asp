using CountryEntity= ecommerce.Domain.Entities.Country;
using ecommerce.Dto.Results.Admin.Country;
using Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Country
{
    public interface ICountryRepository : Repositories.Base.IgenericRepository<ecommerce.Domain.Entities.Country>
    {



        public List<GetAllCountriesDto> GetAllCountries();
        
        
        public CountryEntity GetCountry(Guid id);


    }
}
