using ecommerce.Domain.Entities.Country;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.infrutructure.Configration
{
    internal class CountryConfigration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasConversion(CountryId => CountryId.Value, Value => new CountryId(Value));

            builder.HasIndex(c=>c.Name).IsUnique();
            
            builder.HasMany(c => c.Cities)
            .WithOne(c => c.Country)
            .OnDelete(DeleteBehavior.Cascade);

            builder.Property(c => c.Status)
                   .HasDefaultValue(false);

        }
    }
}
