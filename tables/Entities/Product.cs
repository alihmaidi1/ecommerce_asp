using ecommerce.Domain.Base.Entity;
using ecommerce.Domain.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tables.Base.Entity;

namespace ecommerce.Domain.Entities;

    public class Product: Imagable
    {
        
        public Product()
        {
            
            Properties=new HashSet<Property>();
            Tags= new HashSet<Tag>();
            Reviews=new HashSet<Review>();


        }

        public string Name { get; set; }
        public string Title { get; set; }

        public ICollection<Image> images { get; set; }

        
        public string Description { get; set; }

        public string MetaTitle { get; set; }

        public string MetaDescription { get; set; }

        public Image MetaLogo { get; set; }

        public Category Category { get; set; }  

        public float Price { get; set; }    
    
    
        public int Quantity  { get; set; }

        public int MinQuantity { get; set; }

        public int SellingNumber { get; set; }

        public Brand? Brand { get; set; }

        public Copon? Copon { get; set; }   


        public ICollection<Property>Properties { get; set; }

        public ICollection<Tag>Tags { get; set; }
        public ICollection<Review> Reviews { get; set; }






}

