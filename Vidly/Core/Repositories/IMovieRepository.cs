using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.Core.Repositories
{
    public interface IMovieRepository : IRepository<Movie>
    {
        Movie GetWithGenre(int Id);

        IEnumerable<Movie> GetAllWithGenre();
    }
}