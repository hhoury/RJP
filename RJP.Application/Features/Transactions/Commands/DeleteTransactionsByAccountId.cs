using AutoMapper;
using MediatR;
using RJP.Application.Contracts.Persistence;
using RJP.Application.Exceptions;
using RJP.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RJP.Application.Features.Transactions.Commands
{
    public class DeleteTransactionsByAccountId : IRequest<bool>
    {
        public int AccountId { get; set; }
        public class DeleteTransactionsByAccountIdHandler : IRequestHandler<DeleteTransactionsByAccountId,bool>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;
            public DeleteTransactionsByAccountIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;   
            }

            public async Task<bool> Handle(DeleteTransactionsByAccountId command, CancellationToken cancellationToken)
            {
                var transactionList = await _unitOfWork.TransactionRepository.GetByAccountId(command.AccountId);
                if (transactionList == null)
                {
                    throw new NotFoundException(nameof(Transaction), command.AccountId);
                }
                await _unitOfWork.TransactionRepository.DeleteTransactionsByAccountId(command.AccountId);
                await _unitOfWork.Save();
                return true;
            }
        }
    }
}
