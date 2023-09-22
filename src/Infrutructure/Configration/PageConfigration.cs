using ecommerce.Domain.Entities.Page;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.infrutructure.Configration
{
    public class PageConfigration : IEntityTypeConfiguration<Page>
    {
        public void Configure(EntityTypeBuilder<Page> builder)
        {
            builder.HasKey(x => x.Id);
            
            builder.Property(x=>x.Id)
                .HasConversion(PageId=>PageId.Value,Value=>new PageId(Value));
        
        }

    }
}
