using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tables.Base.Entity;

namespace ecommerce.Domain.Entities
{
    public class Category :BaseEntity
    {
        public Category()
        {
            Child = new HashSet<Category>();
            Products= new HashSet<Product>();

        }
        public string Name { get; set; }

        public Category Parent { get;set; }
        public ICollection<Category> Child { get; set; }

        public ICollection<Product> Products { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public int Rank { get; set; }
        public string ? Meta_Description { get; set; }
        public string ? Meta_Title { get; set; }
        public string ? Meta_Logo { get; set; }


    }
}
