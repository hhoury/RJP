using AutoMapper;
using MediatR;
using RJP.Application.Contracts.Persistence;
using RJP.Application.DTOs;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace RJP.Application.Features.Transactions.Queries
{
    public class GetTransactionsByAccountIdQuery : IRequest<IEnumerable<TransactionDto>>
    {
        public int AccountId { get; set; }

        public class GetTransactionsByAccountIdQueryHandler : IRequestHandler<GetTransactionsByAccountIdQuery, IEnumerable<TransactionDto>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;
            public GetTransactionsByAccountIdQueryHandler(IUnitOfWork unitOfWork,IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<IEnumerable<TransactionDto>> Handle(GetTransactionsByAccountIdQuery request, CancellationToken cancellationToken)
            {
                var transactionsList = await _unitOfWork.TransactionRepository.GetByAccountId(request.AccountId);
                return _mapper.Map<IEnumerable<TransactionDto>>(transactionsList);  
            }
        }
    }
}
