using AutoMapper;
using MediatR;
using RJP.Application.Contracts.Persistence;
using RJP.Application.DTOs;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace RJP.Application.Features.Transactions.Queries
{
    public class GetAllTransactionsQuery : IRequest<IEnumerable<TransactionDto>>
    {
        public int AccountId { get; set; }
        public class GetAllTransactionsQueryHandler : IRequestHandler<GetAllTransactionsQuery, IEnumerable<TransactionDto>>
        {
            private readonly ITransactionRepository _transactionRepository;
            private readonly IMapper _mapper;
            public GetAllTransactionsQueryHandler(ITransactionRepository transactionRepository,IMapper mapper)
            {
                _transactionRepository = transactionRepository;
                _mapper = mapper;
            }

            public async Task<IEnumerable<TransactionDto>> Handle(GetAllTransactionsQuery query, CancellationToken cancellationToken)
            {
                var transactionsList = await _transactionRepository.GetByAccountId(query.AccountId);
                return _mapper.Map<IEnumerable<TransactionDto>>(transactionsList);  
            }
        }
    }
}
