using ecommerce.Domain.Base.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tables.Base.Entity;

namespace ecommerce.Domain.Entities
{
    public class Country: BaseEntityWithoutId
    {

        public Country()
        {

            Cities = new HashSet<City>();   

        }

        public int Id { get; set; }

        public string Name { get; set; }
        public string Code { get; set; }

        public int lat { get; set; } 
        public int lon { get; set; }
    
        public ICollection<City> Cities { get; set;}

    }
}
