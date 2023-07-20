using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tables.Base.Entity;

namespace ecommerce.Domain.Entities
{
    public class Tag: BaseEntity
    {
        public Tag()
        {

            Products=new HashSet<Product>();

        }

        public string Name { get; set; }
        [ForeignKey("ProductId")]
        public ICollection<Product> Products { get; set; }


    }
}
