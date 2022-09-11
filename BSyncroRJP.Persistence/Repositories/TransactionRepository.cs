using BSyncroRJP.Persistence;
using Microsoft.EntityFrameworkCore;
using RJP.Application.Contracts.Persistence;
using RJP.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJP.Persistence.Repositories
{
    public class TransactionRepository : GenericRepository<Transaction>, ITransactionRepository
    {
        private readonly RJPDbContext _dbContext;
        public TransactionRepository(RJPDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> DeleteTransactionsByAccountId(int accountId)
        {
            var transactionsList = await _dbContext.Transactions.Where(trx => trx.AccountId == accountId).ToListAsync();
            _dbContext.Transactions.RemoveRange(transactionsList);
            return true;
        }

        public async Task<IReadOnlyList<Transaction>> GetByAccountId(int accountId)
        {
            var transactionsList = await _dbContext.Transactions.Where(trx => trx.AccountId == accountId)
                .Include(trx => trx.Account)
                .Include(acc => acc.Account.Customer).ToListAsync();
            return transactionsList;
        }
    }
}
