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
    internal class CityConfigration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.Property(c => c.Delivery_Price).HasDefaultValue(0);
            builder.Property(c=>c.status).HasDefaultValue(false);
            builder.HasMany(c => c.Users)
                   .WithOne(u => u.City);

        }
    }
}
