using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Core.Repositories;
using Vidly.Models;

namespace Vidly.Persistence.Repositories
{
    public class CustomerRepository: Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ApplicationDbContext context)
            :base(context)
        {
        }

        public ApplicationDbContext VidlyContext
        {
            get { return Context as ApplicationDbContext; }
        }
    }
}