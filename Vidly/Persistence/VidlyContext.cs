using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.Persistence
{
    public class VidlyContext: DbContext
    {
        public VidlyContext()
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}