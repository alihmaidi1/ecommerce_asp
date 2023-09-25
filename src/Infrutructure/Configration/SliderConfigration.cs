using ecommerce.Domain.Entities.Slider;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.infrutructure.Configration
{
    public class SliderConfigration : IEntityTypeConfiguration<Slider>
    {
        public void Configure(EntityTypeBuilder<Slider> builder)
        {

            builder.HasKey(x=>x.Id);
            builder.Property(x => x.Id)
                .HasConversion(SliderId => SliderId.Value,Value=>new SliderId(Value));

            builder.HasIndex(s => s.Rank).IsUnique();

        }
    }
}
