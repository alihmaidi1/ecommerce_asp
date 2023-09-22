using ecommerce.Domain.Entities.Property;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.infrutructure.Configration
{
    public class PropertyConfigration : IEntityTypeConfiguration<Property>
    {
        public void Configure(EntityTypeBuilder<Property> builder)
        {

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasConversion(PropertyId => PropertyId.Value, Value => new PropertyId(Value)); ;


            builder.HasIndex(p=>p.Name).IsUnique();
        }
    }
}
