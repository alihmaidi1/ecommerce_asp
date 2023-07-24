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
            
            Properties=new HashSet<Property>();
//            Images= new HashSet<string>();
            Reviews=new HashSet<Review>();


        }

//    public ICollection<Tag> Tags { get; set; }

        public string Name { get; set; }
        public string Title { get; set; }

//        public ICollection<string> Images { get; set; }

        
        public string Description { get; set; }

        public string MetaTitle { get; set; }

        public string MetaDescription { get; set; }

        public string MetaLogo { get; set; }

        public Category Category { get; set; }  

        public float Price { get; set; }    
    
    
        public int Quantity  { get; set; }

        public int MinQuantity { get; set; }

        public int SellingNumber { get; set; }

        public Brand? Brand { get; set; }

        public Copon? Copon { get; set; }   


        public ICollection<Property>Properties { get; set; }


        public ICollection<Review> Reviews { get; set; }

        






}

