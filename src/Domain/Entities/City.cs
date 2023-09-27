using System.ComponentModel.DataAnnotations;

using ecommerce.Domain.Entities.Identity;
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
