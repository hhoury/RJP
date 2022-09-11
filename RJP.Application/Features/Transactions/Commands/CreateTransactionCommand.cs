using AutoMapper;
using FluentValidation;
using MediatR;
using RJP.Application.Contracts.Persistence;
using RJP.Application.DTOs;
using RJP.Application.DTOs.Validators;
using RJP.Domain;
using System;
using System.Threading;
using System.Threading.Tasks;


namespace RJP.Application.Features.Transactions.Commands
{
    public class CreateTransactionCommand : IRequest<int>
    {
        public TransactionDto TransacionDto{ get; set; }
        public class CreateTransactionCommandHandler : IRequestHandler<CreateTransactionCommand, int>
        {
            private readonly IUnitOfWork _unitOfWork;

            private readonly IMapper _mapper;
            public CreateTransactionCommandHandler(IUnitOfWork unitOfWork,IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<int> Handle(CreateTransactionCommand command, CancellationToken cancellationToken)
            {
                var validator = new TransactionDtoValidator(_unitOfWork.AccountRepository);
                var validationResult = await validator.ValidateAsync(command.TransacionDto);

                if (!validationResult.IsValid)
                {
                    throw new Exception();
                }
                var transaction = _mapper.Map<Transaction>(command.TransacionDto);
                transaction = await _unitOfWork.TransactionRepository.Add(transaction);
                await _unitOfWork.Save();
                return transaction.Id;
            }
        }
    }
}
