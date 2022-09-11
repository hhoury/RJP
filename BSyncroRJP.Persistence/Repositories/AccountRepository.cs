using Microsoft.EntityFrameworkCore;
using RJP.Application.Contracts.Persistence;
using RJP.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BSyncroRJP.Persistence.Repositories
{
    public class AccountRepository : GenericRepository<Account> ,IAccountRepository
    {
        private readonly RJPDbContext _dbContext;
        public AccountRepository(RJPDbContext dbContext) : base(dbContext)
        {
           _dbContext = dbContext;
        }

        public async Task<bool> DeleteAccountsByCustomerId(int customerId)
        {
            var accountsList = await _dbContext.Accounts.Where(acc => acc.CustomerId == customerId).ToListAsync();
            _dbContext.RemoveRange(accountsList);
            return true;
        }

        public async Task<IReadOnlyList<Account>> GetByCustomerId(int customerId)
        {
            var accountsList = await _dbContext.Accounts.Where(acc => acc.CustomerId == customerId).ToListAsync();
            return accountsList;
        }
    }
}
