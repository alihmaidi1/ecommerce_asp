using ecommerce.Domain.Base.Interfaces;
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
            images = new HashSet<Image>();

        }
        public string Name { get; set; }

        public virtual ICollection<Image>? images { get; set; }
        public virtual Category? Parent { get;set; }
        public virtual ICollection<Category> Child { get; set; }

        public virtual ICollection<Product> Products { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public int Rank { get; set; }
        public string ? Meta_Description { get; set; }
        public string ? Meta_Title { get; set; }

//        public ICollection<Tag> Tags { get; set; }



    }
}
