using RJP.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RJP.Application.Contracts.Persistence
{
    public interface ITransactionRepository : IGenericRepository<Transaction>
    {
        Task<IReadOnlyList<Transaction>> GetByAccountId(int accountId);
        Task<bool> DeleteTransactionsByAccountId(int accountId);
    }
}
