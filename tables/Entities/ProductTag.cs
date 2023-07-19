using ecommerce.Domain.Base.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.Domain.Entities
{
    public class ProductTag:BaseEntityWithoutId
    {

        public Guid ProductId { get; set; }
        public Guid TagId { get; set; }

        public Product Product { get; set; }

        public Tag Tag { get; set; }


    }
}
