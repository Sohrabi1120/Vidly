using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using Vidly.Core.Repositories;
using Vidly.Models;
using System.Data.Entity;

namespace Vidly.Persistence.Repositories
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {
        public MovieRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public ApplicationDbContext ApplicationDbContext
        {
            get { return Context; }
        }

        public Movie GetWithGenre(int Id)
        {
            return Context.Movies.Include(m => m.Genre).Where(m => m.Id == Id).Single();
        }

        public IEnumerable<Movie> GetAllWithGenre()
        {
            return Context.Movies.Include(m => m.Genre).ToList();
        }
    }
}