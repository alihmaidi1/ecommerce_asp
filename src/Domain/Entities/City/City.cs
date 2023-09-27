using System.ComponentModel.DataAnnotations;
<<<<<<< HEAD:src/Domain/Entities/City/City.cs
using CountryEntity=ecommerce.Domain.Entities.Country.Country;
=======

>>>>>>> ed:src/Domain/Entities/City.cs
using ecommerce.Domain.Entities.Identity;
using tables.Base.Entity;
using ecommerce.Domain.Entities.Country;

namespace ecommerce.Domain.Entities.City
{
    public class City: BaseEntity<CityId>
    {

        public City() {
        
            Users = new HashSet<User>();
            Id = new CityId(Guid.NewGuid());
        }


        public string Name { get; set; }

        public CountryId CountryId { get; set; }

        public virtual CountryEntity Country { get; set; }

        public Boolean status { get; set; }

        [Range(0,Double.MaxValue)]
        public float Delivery_Price { get; set; }    

        public virtual ICollection<User> Users { get; set; }


    }
}
