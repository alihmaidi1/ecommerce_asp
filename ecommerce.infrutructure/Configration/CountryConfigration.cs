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
    internal class CountryConfigration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {

            builder.HasIndex(c=>c.Name).IsUnique();
            builder.HasMany(c => c.Cities).WithOne(c => c.Country);

        }
    }
}
