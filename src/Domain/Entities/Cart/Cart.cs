using ecommerce.Domain.Base.Entity;
using ecommerce.Domain.Entities.Identity;
using ProductEntity=ecommerce.Domain.Entities.Product.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ecommerce.Domain.Entities.Product;

namespace ecommerce.Domain.Entities.Cart;

public class Cart : BaseEntityWithoutId
{


    public int quantity { get; set; }

    public ProductId ProductId { get; set; }

    public virtual ProductEntity Product { get; set; }
    public Guid UserId { get; set; }
    public virtual User User { get; set; }




}

