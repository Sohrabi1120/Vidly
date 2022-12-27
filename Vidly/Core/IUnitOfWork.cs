using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Core.Repositories;

namespace Vidly.Core
{
    public interface IUnitOfWork: IDisposable
    {
        IMovieRepository Movies { get; }
        ICustomerRepository Customers { get; }
        IGenreRepository Genres { get; }
        int Complete();
    }
}