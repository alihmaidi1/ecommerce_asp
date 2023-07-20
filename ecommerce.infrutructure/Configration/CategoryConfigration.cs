using ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tables.Entities;

namespace ecommerce.infrutructure.Configration
{
    public class CategoryConfigration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasIndex(c=>c.Name).IsUnique();
            builder.HasIndex(c => c.Rank).IsUnique();
            builder.HasMany(c => c.Child).WithOne(c => c.Parent);
            builder.HasMany(c=>c.Products).WithOne(p=>p.Category);

        }
    }
}
