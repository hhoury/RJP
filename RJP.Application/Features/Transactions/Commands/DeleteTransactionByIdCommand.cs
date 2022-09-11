using AutoMapper;
using MediatR;
using RJP.Application.Contracts.Persistence;
using RJP.Application.Exceptions;
using RJP.Domain;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RJP.Application.Features.Transactions.Commands
{
    public class DeleteTransactionByIdCommand : IRequest<bool>
    {
        public int Id { get; set; }

        public class DeleteTransactionByIdCommandHandler : IRequestHandler<DeleteTransactionByIdCommand, bool>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;
            public DeleteTransactionByIdCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<bool> Handle(DeleteTransactionByIdCommand command, CancellationToken cancellationToken)
            {
                var transaction = await _unitOfWork.TransactionRepository.Get(command.Id);
                if(transaction == null)
                {
                    throw new NotFoundException(nameof(Transaction), command.Id);
                }
                await _unitOfWork.TransactionRepository.Delete(transaction);
                await _unitOfWork.Save();
                return true;
            }
        }
    }
}
