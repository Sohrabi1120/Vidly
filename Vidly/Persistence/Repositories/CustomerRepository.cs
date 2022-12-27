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
    public class CustomerRepository: Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ApplicationDbContext context)
            :base(context)
        {
        }

        public ApplicationDbContext ApplicationDbContext
        {
            get { return Context as ApplicationDbContext; }
        }

        public Customer GetWithMembershipType(int Id)
        {
            return Context.Customers.Include(c => c.MembershipType).Where(c => c.Id ==Id).Single();
        }

        public IEnumerable<Customer> GetAllWithMembershiptype()
        {
            return Context.Set<Customer>().Include(c => c.MembershipType).ToList();
        }
    }
}