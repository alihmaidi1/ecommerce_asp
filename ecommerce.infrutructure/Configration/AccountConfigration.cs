﻿using ecommerce.Domain.Abstract;
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


        }
    }
}
