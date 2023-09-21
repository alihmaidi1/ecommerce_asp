using ecommerce.Domain.Entities.Identity;
using ecommerce_shared.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.infrutructure.Configration
{
    public class AccountConfigration: IEntityTypeConfiguration<Account>

    {


        public void Configure(EntityTypeBuilder<Account> builder)
        {

            builder.HasMany(a => a.RefreshTokens)
                   .WithOne(r => r.Account);

            builder.Property(x => x.ProviderType)
                   .HasDefaultValue(ProviderAuthentication.Local);

            builder.Property(x=>x.IsBlocked)
                   .HasDefaultValue(false);
        }
    }
}
