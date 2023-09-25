using ecommerce.Domain.Entities.Coupon;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.infrutructure.Configration
{
    public class CoponConfigration : IEntityTypeConfiguration<Coupon>
    {
        public void Configure(EntityTypeBuilder<Coupon> builder)
        {

            builder.HasKey(x => x.Id);

            builder.Property(x=>x.Id)
                .HasConversion(CouponId=>CouponId.Value,Value=>new CouponId(Value));

            builder.HasIndex(c=>c.Name).IsUnique();
            
            
            builder.HasMany(c=>c.Products)
            .WithOne(p=>p.Copon)
            .OnDelete(DeleteBehavior.SetNull);


        }
    }
}
