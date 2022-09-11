using AutoMapper;
using MediatR;
using RJP.Application.Contracts.Persistence;
using RJP.Application.Exceptions;
using RJP.Domain;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RJP.Application.Features.Accounts.Commands
{
    public class DeleteAccountsByCustomerIdCommand : IRequest<bool>
    {
        public int CustomerId { get; set; }

        public class DeleteAccountsByCustomerIdCommandHandler : IRequestHandler<DeleteAccountsByCustomerIdCommand, bool>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;
            public DeleteAccountsByCustomerIdCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<bool> Handle(DeleteAccountsByCustomerIdCommand command, CancellationToken cancellationToken)
            {
                var accounts = await _unitOfWork.AccountRepository.GetByCustomerId(command.CustomerId);
                if(accounts == null)
                {
                    throw new NotFoundException(nameof(Account),command.CustomerId);
                }
                await _unitOfWork.AccountRepository.DeleteAccountsByCustomerId(command.CustomerId);
                await _unitOfWork.Save();
                return true;
            }
        }


    }
}
