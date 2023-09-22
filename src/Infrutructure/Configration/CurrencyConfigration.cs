using ecommerce.Domain.Entities.Currency;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.infrutructure.Configration;

public class CurrencyConfigration : IEntityTypeConfiguration<Currency>
{
    public void Configure(EntityTypeBuilder<Currency> builder)
    {

        builder.HasKey(x => x.Id);

        builder.Property(x=>x.Id)
            .HasConversion(CurrencyId=>CurrencyId.Value,Value=>new CurrencyId(Value));

        builder.HasIndex(c => c.Name).IsUnique();
        builder.HasIndex(c=>c.Code).IsUnique();
        
    }
}

