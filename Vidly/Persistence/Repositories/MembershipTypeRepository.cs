using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Core.Repositories;
using Vidly.Models;

namespace Vidly.Persistence.Repositories
{
    public class MembershipTypeRepository : Repository<MembershipType>, IMembershipTypeRepository
    {
        public MembershipTypeRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public ApplicationDbContext ApplicationDbContext
        {
            get { return Context as ApplicationDbContext; }
        }
    }
}