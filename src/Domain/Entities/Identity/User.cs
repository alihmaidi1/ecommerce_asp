using ecommerce_shared.Enums;
using System.ComponentModel.DataAnnotations;
using tables.Base.Entity;

namespace ecommerce.Domain.Entities.Identity
{
    public class User:Account
    {
        
        public Guid ?CityId { get; set; }

        public virtual City ?City { get; set; }


        public string Name { get; set; }
         
        [Range(0,Double.MaxValue)]
        public int Point { get; set; }



        public string ? Logo { get; set; }  

        public string ? hash {get; set;}

        public string resizedLogo { get; set;}


        
        
        
    
    }
}
