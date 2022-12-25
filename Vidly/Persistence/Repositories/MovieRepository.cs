﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Core.Repositories;
using Vidly.Models;

namespace Vidly.Persistence.Repositories
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {
        public MovieRepository(VidlyContext context)
            : base(context)
        {
        }

        public VidlyContext VidlyContext
        {
            get { return Context as VidlyContext; }
        }
    }
}