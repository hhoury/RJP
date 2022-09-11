using RJP.Application.Contracts.Persistence;
using System;
using System.Threading.Tasks;

namespace BSyncroRJP.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RJPDbContext _context;
        private IAccountRepository _accountRepository;
        private ICustomerRepository _customerRepository;
        private ITransactionRepository _transactionRepository;

        public UnitOfWork(RJPDbContext context)
        {
            _context = context;
        }
        public IAccountRepository AccountRepository =>
           _accountRepository ??= new AccountRepository(_context);
        public ICustomerRepository CustomerRepository =>
            _customerRepository ??= new CustomerRepository(_context);
        public ITransactionRepository TransactionRepository =>
            _transactionRepository ??= new TransactionRepository(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
