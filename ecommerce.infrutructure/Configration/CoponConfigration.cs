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
    public class CoponConfigration : IEntityTypeConfiguration<Copon>
    {
        public void Configure(EntityTypeBuilder<Copon> builder)
        {
            builder.HasIndex(c=>c.Name).IsUnique();
            builder.HasMany(c=>c.Products).WithOne(p=>p.Copon);

        }
    }
}
