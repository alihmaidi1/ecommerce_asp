using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.Domain.Entities
{
    public class Review:baseEntityWithoutId
    {

        public Product Product { get; set; }    

        public string Content  { get; set; }    


        public int stars { get; set; }  


    }
}
