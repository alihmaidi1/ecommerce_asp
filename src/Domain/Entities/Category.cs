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
            Images = new HashSet<ImageCategory>();
            


        }
        public string Name { get; set; }

        public string Description { get; set; }
        public bool Status { get; set; } = true;

        public int Rank { get; set; }

        public string? Meta_Title { get; set; }

        public string? Meta_Description { get; set; }

        public virtual ICollection<ImageCategory> Images { get; set; }
        

        public virtual ICollection<Product> Products { get; set; }
        
        public Guid ?ParentId { get; set; }

        
        public virtual Category? Parent { get;set; }
        

        public virtual ICollection<Category> Child { get; set; }





    }
}
