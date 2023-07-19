using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ecommerce.Domain.Entities;

    public class Cart:baseEntityWithoutId
    {

        public int quantity { get; set; }
        
        public Product Product { get; set; }




    }

