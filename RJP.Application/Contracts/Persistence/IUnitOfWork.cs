using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RJP.Application.Contracts.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        IAccountRepository AccountRepository { get; }
        ICustomerRepository CustomerRepository { get; }
        ITransactionRepository TransactionRepository{ get; }
        Task Save();
    }
}
