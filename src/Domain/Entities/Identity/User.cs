using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tables.Base.Entity;

namespace ecommerce.Domain.Entities.Identity
{
    public class User:BaseEntity
    {
        public Guid Id { get; set; }


        public Guid CityId { get; set; }

        public virtual City City { get; set; }


        public string Name { get; set; }
         
        [Range(0,Double.MaxValue)]
        public int Point { get; set; }


        public Guid AccountId { get; set; } 

        public virtual Account Account { get; set; }
        
        public bool IsBlocked { get; set; }

    
    }
}
