<<<<<<< HEAD
﻿//using CountryEntity = ecommerce.Domain.Entities.Country.Country;
//using ecommerce.Dto.Results.Admin.Country;
//using Repositories.Base;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
=======
﻿using CountryEntity= ecommerce.Domain.Entities.Country;
using ecommerce.Dto.Results.Admin.Country;
using Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ecommerce.Dto.Results.User.City.Query;
>>>>>>> ed

//namespace Repositories.Country
//{
//    public interface ICountryRepository : Repositories.Base.IgenericRepository<CountryEntity>
//    {



//        public List<GetAllCountriesDto> GetAllCountries();
        
        public List<GetAllCountriesDto> GetAllActiveCountries();


        public List<OnlyCityDto> GetActiveCities(Guid CountryId);
        
//        public GetCountryResponse GetCountry(Guid id);
//        public bool IsExists(Guid Id);

<<<<<<< HEAD
//        public bool Active(Guid Id);
=======
        public bool IsActiveExists(Guid Id);

        public bool Active(Guid Id);
>>>>>>> ed


//        public bool UnActive(Guid Id);
        


//    }
//}
