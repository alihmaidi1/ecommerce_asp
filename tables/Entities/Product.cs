using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tables.Base.Entity;

namespace ecommerce.Domain.Entities;

    public class Product: BaseEntity
    {
        
        public Product()
        {
            
            Properties=new HashSet<ProductProperty>();
            Tag= new HashSet<ProductTag>();


        }

    public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public string MetaTitle { get; set; }

        public string MetaDescription { get; set; }

        public Category Category { get; set; }  

        public float Price { get; set; }    
    
    
        public int Quantity  { get; set; }

        public int MinQuantity { get; set; }

        public int SellingNumber { get; set; }

        public Brand? Brand { get; set; }

        public Copon? Copon { get; set; }   


        public ICollection<ProductProperty>Properties { get; set; }

        public ICollection<ProductTag>Tag { get; set; }





    }

