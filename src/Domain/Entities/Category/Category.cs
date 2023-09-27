using ecommerce.Domain.Base.Interfaces;
using ProductEntity=ecommerce.Domain.Entities.Product.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tables.Base.Entity;

namespace ecommerce.Domain.Entities.Category
{
    public class Category :BaseEntity<CategoryId>
    {
        public Category()
        {
            Child = new HashSet<Category>();
            Products= new HashSet<ProductEntity>();
            Images = new HashSet<ImageCategory>();
            Id = new CategoryId(Guid.NewGuid());
            
            


        }
        public string Name { get; set; }

        public string Description { get; set; }
        public bool Status { get; set; } = true;

        public int Rank { get; set; }

        public string? Meta_Title { get; set; }

        public string? Meta_Description { get; set; }

        public virtual ICollection<ImageCategory> Images { get; set; }
        

        public virtual ICollection<ProductEntity> Products { get; set; }
        
        public CategoryId? ParentId { get; set; }

        
        public virtual Category? Parent { get;set; }
        
        public virtual ICollection<Category> Child { get; set; }
        


    }
}
