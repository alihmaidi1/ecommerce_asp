using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tables.Base.Entity;

namespace ecommerce.Domain.Entities
{
    public class City: BaseEntity
    {

        public City() {
        

            Users = new HashSet<User>();
        }


        public string Name { get; set; }

        public Guid CountryId { get; set; }

        public virtual Country Country { get; set; }

        public Boolean status { get; set; }

        [Range(0,Double.MaxValue)]
        public float Delivery_Price { get; set; }    

        public virtual ICollection<User> Users { get; set; }


    }
}
