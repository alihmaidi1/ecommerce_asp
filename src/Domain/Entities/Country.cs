using ecommerce.Domain.Base.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using tables.Base.Entity;

namespace ecommerce.Domain.Entities
{
    public class Country: BaseEntity
    {

        public Country()
        {

            Cities = new HashSet<City>();   

        }

        
        public string Name { get; set; }
        public string Code { get; set; }


        public double lat { get; set; }
    
        public virtual ICollection<City> Cities { get; set;}

        public bool Status { get; set; }

        public static Expression<Func<Country, Country>> SelectIDAndName = c => new Country
        {

            Name = c.Name,
            Id = c.Id,

        };

    }
}
