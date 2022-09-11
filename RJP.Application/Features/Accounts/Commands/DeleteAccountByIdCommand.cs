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
    public class DeleteAccountByIdCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public class DeleteAccountByIdCommandHandler : IRequestHandler<DeleteAccountByIdCommand, bool>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;
            public DeleteAccountByIdCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }
            public async Task<bool> Handle(DeleteAccountByIdCommand command, CancellationToken cancellationToken)
            {
                var account = await _unitOfWork.AccountRepository.Get(command.Id);
                if(account == null)
                {
                    throw new NotFoundException(nameof(Account), command.Id);
                }
                await _unitOfWork.AccountRepository.Delete(account);
                await _unitOfWork.Save();
                return true;
            }
        }
    }
}
