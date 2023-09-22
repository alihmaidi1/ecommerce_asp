using ecommerce.Domain.Entities.Wishlist;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ecommerce.Domain.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.infrutructure.Configration
{
    internal class WishlistConfigration : IEntityTypeConfiguration<Wishlist>
    {
        public void Configure(EntityTypeBuilder<Wishlist> builder)
        {
            builder.HasKey(w => new { w.ProductId,w.UserId });

            builder.Property(x => x.ProductId)
                .HasConversion(ProductId => ProductId.Value, Value => new ProductId(Value));

            
        }

    }
}
