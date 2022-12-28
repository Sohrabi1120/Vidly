using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.Core.Repositories
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Customer GetWithMembershipType(int Id);

        IEnumerable<Customer> GetAllWithMembershiptype();
    }
}