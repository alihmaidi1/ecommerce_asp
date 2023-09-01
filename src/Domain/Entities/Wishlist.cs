using ecommerce.Domain.Base.Entity;
using ecommerce.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.Domain.Entities
{
    public class Wishlist:BaseEntityWithoutId
    {

        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }

        public Guid UserId { get; set; }

        public virtual User User { get; set; }
        


    }
}
