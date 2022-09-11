using BSyncroRJP.Persistence;
using RJP.Application.Contracts.Persistence;
using RJP.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace RJP.Persistence.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        private readonly RJPDbContext _dbContext;
        public CustomerRepository(RJPDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

    }
}
