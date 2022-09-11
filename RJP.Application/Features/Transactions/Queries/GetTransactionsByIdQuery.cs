using AutoMapper;
using MediatR;
using RJP.Application.Contracts.Persistence;
using RJP.Application.DTOs;
using RJP.Domain;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace RJP.Application.Features.Transactions.Queries
{
    public class GetTransactionsByIdQuery : IRequest<TransactionDto>
    {
        public int Id { get; set; }
        public class GetTransactionsByIdQueryHandler : IRequestHandler<GetTransactionsByIdQuery, TransactionDto>
        {
            private readonly ITransactionRepository _transactionRepository;
            private readonly IMapper _mapper;
            public GetTransactionsByIdQueryHandler(ITransactionRepository transactionRepository,IMapper mapper)
            {
                _transactionRepository = transactionRepository;
                _mapper = mapper;
            }

            public async Task<TransactionDto> Handle(GetTransactionsByIdQuery query, CancellationToken cancellationToken)
            {
                var transaction = await _transactionRepository.Get(query.Id);
                if (transaction == null) return null;
                return _mapper.Map<TransactionDto>(transaction);
            }
        }
    }
}
