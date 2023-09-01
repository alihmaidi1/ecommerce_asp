using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tables.Entities;
using ecommerce.Domain.Entities.Identity;

namespace ecommerce.infrutructure.Configration
{

    public class UserConfigration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {

            builder.Property(u => u.Point).HasDefaultValue(0);
            builder.Property(u=>u.IsBlocked).HasDefaultValue(false);
            

        }
    }
}
