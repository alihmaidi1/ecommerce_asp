<<<<<<< HEAD
﻿using ecommerce.Domain.Entities.Identity;
=======
﻿
using ecommerce.Domain.Entities;
>>>>>>> 90bac4133691690d5adc946ac38d3faf668d9f45
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
