using ecommerce.Domain.Base.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ecommerce.Domain.Entities;

    public class Cart:BaseEntityWithoutId
    {


        public int quantity { get; set; }

        public Guid ProductId  { get; set; }
        
        public Product Product { get; set; }




    }

