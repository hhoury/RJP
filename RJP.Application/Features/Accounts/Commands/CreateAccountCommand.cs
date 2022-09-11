using AutoMapper;
using MediatR;
using RJP.Application.Contracts.Persistence;
using RJP.Application.DTOs;
using RJP.Application.DTOs.Validators;
using RJP.Domain;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace RJP.Application.Features.Accounts.Commands
{
    public class CreateAccountCommand : IRequest<int>
    {
        public AccountDto AccountDto{ get; set; }

        public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, int>
        {
            private readonly IUnitOfWork _unitOfWork;

            private readonly IMapper _mapper;
            public CreateAccountCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }
            public async Task<int> Handle(CreateAccountCommand command, CancellationToken cancellationToken)
            {
                var validator = new AccountDtoValidator(_unitOfWork.CustomerRepository);
                var validationResult = await validator.ValidateAsync(command.AccountDto);

                if (!validationResult.IsValid)
                {
                    throw new Exception();
                }

                var account = _mapper.Map<Account>(command.AccountDto);
                account = await _unitOfWork.AccountRepository.Add(account);
                await _unitOfWork.Save();
                return account.Id;

            }
        }
    }
}
