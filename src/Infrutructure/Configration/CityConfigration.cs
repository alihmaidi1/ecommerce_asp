using ecommerce.Domain.Entities.City;
using Microsoft.EntityFrameworkCore;
using ecommerce.Domain.Entities.Country;
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

            builder.HasKey(x => x.Id);

            builder.Property(x=>x.Id)
                .HasConversion(CityId=>CityId.Value,Value=>new CityId(Value));

            builder.Property(x => x.CountryId)
                .HasConversion(CountryId => CountryId.Value, Value => new CountryId(Value));


            builder.Property(c => c.Delivery_Price).HasDefaultValue(0);

            builder.Property(c=>c.status).HasDefaultValue(false);
            builder.HasMany(c => c.Users)
                   .WithOne(u => u.City);

        }
    }
}
