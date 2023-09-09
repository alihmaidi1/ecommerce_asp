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
            Images= new HashSet<Image>();
            Reviews=new HashSet<Review>();


        }

//    public ICollection<Tag> Tags { get; set; }

        public string Name { get; set; }
        public string Title { get; set; }

        public virtual ICollection<Image> Images { get; set; }

        
        public string Description { get; set; }

        public string MetaTitle { get; set; }

        public string MetaDescription { get; set; }

        public string MetaLogo { get; set; }

        public virtual Category Category { get; set; }  

        public float Price { get; set; }    
    
    
        public int Quantity  { get; set; }

        public int MinQuantity { get; set; }

        public int SellingNumber { get; set; }

        public virtual Brand? Brand { get; set; }

        public virtual Coupon? Copon { get; set; }   


        public virtual ICollection<Property>Properties { get; set; }


        public virtual ICollection<Review> Reviews { get; set; }

        






}

