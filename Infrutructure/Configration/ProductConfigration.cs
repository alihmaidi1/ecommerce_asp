using ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.infrutructure.Configration
{
    public class ProductConfigration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            
            
            builder.Property(p => p.SellingNumber).HasDefaultValue(0);
           

            builder.HasMany(p => p.Properties).WithMany(p=>p.Products).UsingEntity<ProductProperty>();
          

            builder.HasMany(p => p.Reviews)
            .WithOne(r=>r.Product)
            .OnDelete(DeleteBehavior.Cascade);

            

        }   
    }
}
