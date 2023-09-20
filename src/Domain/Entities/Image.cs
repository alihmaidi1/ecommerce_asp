using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tables.Base.Entity;

namespace ecommerce.Domain.Entities
{
    public class Image
    {

        public Guid Id { get; set; }
        public string Url { get; set; }
        public string Resized { get; set; }
        public string Hash { get; set; }


    }


    public class ImageCategory : Image
    {

        public virtual Category? Category { get; set; }


    }


    public class ImageProduct: Image
    {

        public virtual Product? Product { get; set; }


    }

}
