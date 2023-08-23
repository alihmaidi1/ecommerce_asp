using ecommerce.Domain.Abstract;
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
    public class AccountConfigration: IEntityTypeConfiguration<Account>

    {


        public void Configure(EntityTypeBuilder<Account> builder)
        {

            builder.HasOne(a => a.User)
                   .WithOne(u=>u.Account);

            builder.HasOne(a => a.Admin)
                   .WithOne(a => a.Account);
            builder.HasMany(a => a.RefreshTokens)
                   .WithOne(r => r.Account);
        }
    }
}
