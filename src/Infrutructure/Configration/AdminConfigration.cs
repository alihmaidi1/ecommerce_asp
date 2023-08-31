
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
    public class AdminConfigration : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {

            builder.Property(a=>a.IsBlocked)
                   .HasDefaultValue(false);

            builder.HasMany(a => a.RefreshTokens).WithOne(r =>(Admin) r.Account).OnDelete(DeleteBehavior.Cascade);
            
        }
    }
}
