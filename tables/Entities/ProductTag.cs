using ecommerce.Domain.Base.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tables.Base.Entity;

namespace ecommerce.Domain.Entities
{
    public class ProductTag:BaseEntity
    {

        public Guid ProductId { get; set; }
        public Guid TagId { get; set; }

        public Product Product { get; set; }

        public Tag Tag { get; set; }


    }
}
