﻿using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.Persistence.EntityConfigurations
{
    public class MembershipTypeConfiguration : EntityTypeConfiguration<MembershipType>
    {
        public MembershipTypeConfiguration()
        {
            Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(255);
        }
    }
}