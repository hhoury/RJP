using AutoMapper;
using MediatR;
using Microsoft.VisualBasic;
using RJP.Application.Contracts.Persistence;
using RJP.Application.DTOs;
using RJP.Application.DTOs.Validators;
using RJP.Application.Exceptions;
using RJP.Application.Responses;
using RJP.Domain;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RJP.Application.Features.Accounts.Commands
{
    public class CreateAccountCommand : IRequest<BaseCommandResponse>
    {
        public CreateAccountDto CreateAccountDto { get; set; }

        public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, BaseCommandResponse>
        {
            private readonly IUnitOfWork _unitOfWork;

            private readonly IMapper _mapper;
            public CreateAccountCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }
            public async Task<BaseCommandResponse> Handle(CreateAccountCommand command, CancellationToken cancellationToken)
            {
                var response = new BaseCommandResponse();

                var validator = new CreateAccountDtoValidator(_unitOfWork.CustomerRepository);
                var validationResult = await validator.ValidateAsync(command.CreateAccountDto);

                if (!validationResult.IsValid)
                {
                    response.Success = false;
                    response.Message = "Account Creation Failed";
                    response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
                    throw new ValidationException(validationResult);
                }
                else
                {
                    var account = _mapper.Map<Account>(command.CreateAccountDto);
                    account = await _unitOfWork.AccountRepository.Add(account);
                    await _unitOfWork.Save();
                    if (account.Balance > 0)
                    {
                        var createTransaction = new CreateTransactionDto();
                        createTransaction.TransactionAmount = account.Balance;
                        createTransaction.AccountId = account.Id;
                        var transaction = _mapper.Map<Transaction>(createTransaction);
                        await _unitOfWork.TransactionRepository.Add(transaction);
                        await _unitOfWork.Save();
                    }
                    response.Id = account.Id;
                    response.Success = true;
                    response.Message = "Account Creation Successful";
                }


                return response;

            }
        }
    }
}
