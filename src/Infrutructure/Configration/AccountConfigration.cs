﻿
using Microsoft.AspNetCore.Identity;
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
    public class AccountConfigration: IEntityTypeConfiguration<IdentityUser<Guid>>

    {


        public void Configure(EntityTypeBuilder<IdentityUser<Guid>> builder)
        {

            //builder.HasOne(a => a.User)
            //       .WithOne(u=>u.Account);
            builder.UseTptMappingStrategy();

            //builder.HasOne(a => a.Admin)
            //       .WithOne(a => a.Account);
            //builder.HasMany(a => a.RefreshTokens)
            //       .WithOne(r => r.Account);
        }
    }
}
