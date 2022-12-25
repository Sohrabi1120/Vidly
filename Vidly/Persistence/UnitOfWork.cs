﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Core;
using Vidly.Core.Repositories;
using Vidly.Persistence.Repositories;

namespace Vidly.Persistence
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly VidlyContext _context;

        public UnitOfWork(VidlyContext context)
        {
            _context = context;
            Movies = new MovieRepository(context);
            Customers = new CustomerRepository(context);
        }
        public IMovieRepository Movies { get; private set; }
        public ICustomerRepository Customers { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}