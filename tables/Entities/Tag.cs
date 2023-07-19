using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tables.Base.Entity;

namespace ecommerce.Domain.Entities
{
    public  class Tag: BaseEntity
    {
        public Tag()
        {

            Products=new HashSet<ProductTag>();

        }

        public string Name { get; set; }
        public ICollection<ProductTag> Products { get; set; }


    }
}
