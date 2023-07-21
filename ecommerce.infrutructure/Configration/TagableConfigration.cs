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
    public class TagableConfigration : IEntityTypeConfiguration<TageablePivot>
    {
        public void Configure(EntityTypeBuilder<TageablePivot> builder)
        {
            builder.HasKey(t => new { t.TagId,t.TagableId });

        }
    }
}
