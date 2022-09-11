using AutoMapper;
using MediatR;
using RJP.Application.Contracts.Persistence;
using RJP.Application.DTOs;
using RJP.Domain;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace RJP.Application.Features.Transactions.Commands
{
    public class UpdateTransactionCommand : IRequest<Unit>
    {
        public TransactionDto TransactionDto{ get; set; }

        public class UpdateTransactionCommandHandler : IRequestHandler<UpdateTransactionCommand, Unit>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;
            public UpdateTransactionCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;

            }

            public async Task<Unit> Handle(UpdateTransactionCommand command, CancellationToken cancellationToken)
            {
                var transaction = await _unitOfWork.TransactionRepository.Get(command.TransactionDto.Id);
                _mapper.Map(command.TransactionDto, transaction);
                await _unitOfWork.TransactionRepository.Update(transaction);
                await _unitOfWork.Save();
                return Unit.Value;
            }

        }
    }
}

