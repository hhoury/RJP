using RJP.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RJP.Application.Contracts.Persistence
{
    public interface IAccountRepository : IGenericRepository<Account>
    {
        Task<IReadOnlyList<Account>> GetByCustomerId(int customerId);
        Task<bool> DeleteAccountsByCustomerId(int customerId);
    }
}
