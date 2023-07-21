using ecommerce.Domain.Base.Abstract;
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

            Tagable = new HashSet<Tagable>();

        }

        public string Name { get; set; }
        public ICollection<Tagable> Tagable { get; set; }



    }
}
