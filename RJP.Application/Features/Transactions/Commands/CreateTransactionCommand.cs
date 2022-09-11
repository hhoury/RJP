using AutoMapper;
using MediatR;
using RJP.Application.Contracts.Persistence;
using RJP.Application.DTOs;
using RJP.Application.DTOs.Validators;
using RJP.Application.Exceptions;
using RJP.Application.Responses;
using RJP.Domain;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace RJP.Application.Features.Transactions.Commands
{
    public class CreateTransactionCommand : IRequest<BaseCommandResponse>
    {
        public TransactionDto TransacionDto{ get; set; }
        public class CreateTransactionCommandHandler : IRequestHandler<CreateTransactionCommand, BaseCommandResponse>
        {
            private readonly IUnitOfWork _unitOfWork;

            private readonly IMapper _mapper;
            public CreateTransactionCommandHandler(IUnitOfWork unitOfWork,IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<BaseCommandResponse> Handle(CreateTransactionCommand command, CancellationToken cancellationToken)
            {
                var response = new BaseCommandResponse();
                var validator = new TransactionDtoValidator(_unitOfWork.AccountRepository);
                var validationResult = await validator.ValidateAsync(command.TransacionDto);

                if (!validationResult.IsValid)
                {
                    response.Success = false;
                    response.Message = "Transaction Creation Failed";
                    response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
                    throw new ValidationException(validationResult);
                }
                else
                {
                    var transaction = _mapper.Map<Transaction>(command.TransacionDto);
                    transaction = await _unitOfWork.TransactionRepository.Add(transaction);
                    await _unitOfWork.Save();
                    response.Success = true;
                    response.Message = "Transaction Creation Successful";
                }

                return response;
            }
        }
    }
}
