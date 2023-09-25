using ecommerce.Domain.Entities.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ecommerce.Domain.Entities.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.infrutructure.Configration
{
    public class ProductPropertyConfigration : IEntityTypeConfiguration<ProductProperty>
    {
        public void Configure(EntityTypeBuilder<ProductProperty> builder)
        {

            builder.HasKey(p => new { p.PropertyId, p.ProductId });


            builder.Property(x => x.PropertyId)
                .HasConversion(PropertyId => PropertyId.Value, Value => new PropertyId(Value));


            builder.Property(x => x.ProductId)
                .HasConversion(ProductId => ProductId.Value, Value => new ProductId(Value)) ;
        }
    }
}
