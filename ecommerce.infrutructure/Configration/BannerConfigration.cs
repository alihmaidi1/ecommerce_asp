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
    internal class BannerConfigration : IEntityTypeConfiguration<Banner>
    {
        public void Configure(EntityTypeBuilder<Banner> builder)
        {
            builder.HasIndex(b => b.Rank).IsUnique();
            builder.HasOne(b => b.Url)
            .WithOne(i=>(Banner)i.Imagable)
            .HasForeignKey<Image>(i=>i.Imagable_id)
            .OnDelete(DeleteBehavior.Cascade);
         
        }
    }
}
