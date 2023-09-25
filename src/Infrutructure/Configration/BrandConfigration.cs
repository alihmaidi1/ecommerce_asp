using ecommerce.Domain.Entities.Brand;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.infrutructure.Configration
{
    public class BrandConfigration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {

            builder.HasKey(b=>b.Id);
            
            
            builder.Property(b => b.Id)
                .HasConversion(brandId => brandId.Value,value=>new BrandId(value));

            builder.HasIndex(b=>b.Name).IsUnique();

            builder.HasMany(b => b.Products)
            .WithOne(p => p.Brand)            
            .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
