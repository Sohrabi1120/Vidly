using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.Persistence.EntityConfigurations
{
    public class MovieConfiguration: EntityTypeConfiguration<Movie>
    {
        public MovieConfiguration()
        {
            Property(m => m.Name)
                .HasMaxLength(255)
                .IsRequired();
            HasRequired(m => m.Genre)
                .WithMany(g => g.Movies)
                .HasForeignKey(m => m.GenreId)
                .WillCascadeOnDelete(false);

        }
    }
}