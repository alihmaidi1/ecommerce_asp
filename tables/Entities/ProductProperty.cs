using ecommerce.Domain.Base.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.Domain.Entities
{
    public class ProductProperty: BaseEntityWithoutId
    {

        public Guid ProductId { get; set; }
        public Guid PropertyId { get; set; }


        public Product Product { get; set; }

        public Property Property { get; set; }


    }
}
