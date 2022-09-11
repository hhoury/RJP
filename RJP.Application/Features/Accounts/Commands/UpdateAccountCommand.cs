using AutoMapper;
using MediatR;
using RJP.Application.Contracts.Persistence;
using RJP.Application.DTOs;
using RJP.Application.DTOs.Validators;
using RJP.Domain;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace RJP.Application.Features.Accounts.Commands
{
    public class UpdateAccountCommand : IRequest<Unit>
    {
        public AccountDto AccountDto { get; set; }
        public class UpdateAccountCommandHandler : IRequestHandler<UpdateAccountCommand, Unit>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;
            public UpdateAccountCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(UpdateAccountCommand command, CancellationToken cancellationToken)
            {
                var validator = new AccountDtoValidator(_unitOfWork.CustomerRepository);
                var account = await _unitOfWork.AccountRepository.Get(command.AccountDto.Id);
                _mapper.Map(command.AccountDto,account);
                await _unitOfWork.AccountRepository.Update(account);
                await _unitOfWork.Save();
                return Unit.Value;
            }

        }
    }
}
