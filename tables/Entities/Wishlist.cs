using ecommerce.Domain.Base.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.Domain.Entities
{
    public class Wishlist:BaseEntityWithoutId
    {


        public Product Product { get; set; }    
        


    }
}
