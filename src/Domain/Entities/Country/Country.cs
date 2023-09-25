using CityEntity=ecommerce.Domain.Entities.City.City;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using tables.Base.Entity;

namespace ecommerce.Domain.Entities.Country
{
    public class Country: BaseEntity<CountryId>
    {

        public Country()
        {

            Cities = new HashSet<CityEntity>();
            Id = new CountryId(Guid.NewGuid());

        }

        
        public string Name { get; set; }
        public string Code { get; set; }


        public double lat { get; set; }
    
        public virtual ICollection<CityEntity> Cities { get; set;}

        public bool Status { get; set; }

        public static Expression<Func<Country, Country>> SelectIDAndName = c => new Country
        {

            Name = c.Name,
            Id = c.Id,

        };

    }
}
