﻿using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.Persistence.EntityConfigurations
{
    public class CustomerConfiguration: EntityTypeConfiguration<Customer>
    {
        public CustomerConfiguration()
        {
            Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(255);
            HasRequired(c => c.MembershipType)
                .WithMany(m => m.Customers)
                .HasForeignKey(c => c.MembershipTypeId)
                .WillCascadeOnDelete(false);
        }
    }
}