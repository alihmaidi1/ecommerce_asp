using ecommerce.Domain.Entities.Category;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.infrutructure.Configration
{
    public class CategoryConfigration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasConversion(CategoryId => CategoryId.Value, Value => new CategoryId(Value));


            builder.Property(x => x.ParentId)
                .HasConversion(ParentId => ParentId.Value,Value=>new CategoryId(Value));

            builder.HasIndex(c=>c.Name).IsUnique();
            builder.HasIndex(c => c.Rank).IsUnique();

            builder.HasMany(c => c.Products)
            .WithOne(p => p.Category)
            .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Images)
                .WithOne(p => p.Category)
                .OnDelete(DeleteBehavior.Cascade);

            
            builder.HasMany(c => c.Child)
            .WithOne(c => c.Parent)
            .OnDelete(DeleteBehavior.Restrict);


            





        }
    }
}
