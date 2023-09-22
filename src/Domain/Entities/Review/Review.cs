using ecommerce.Domain.Base.Entity;
using ecommerce.Domain.Entities.Identity;
using ProductEntity=ecommerce.Domain.Entities.Product.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ecommerce.Domain.Entities.Product;

namespace ecommerce.Domain.Entities.Review
{
    public class Review : BaseEntityWithoutId
    {

        public ProductId ProductId { get; set; }

        public virtual ProductEntity Product { get; set; }

        public Guid UserId { get; set; }

        public virtual User User { get; set; }

        public string Content { get; set; }

        [Range(0, 5)]
        public int stars { get; set; }


    }
}
