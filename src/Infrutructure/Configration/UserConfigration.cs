﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ecommerce.Domain.Entities.City;
using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ecommerce.Domain.Entities.Identity;

namespace ecommerce.infrutructure.Configration
{

    public class UserConfigration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {

            builder.Property(u => u.Point).HasDefaultValue(0);
            builder.Property(u=>u.IsBlocked).HasDefaultValue(false);
            builder.Property(x => x.CityId)
                .HasConversion(CityId => CityId.Value, Value => new CityId(Value));
            

        }
    }
}
