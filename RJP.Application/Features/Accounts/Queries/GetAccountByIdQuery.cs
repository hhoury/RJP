using MediatR;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;
using RJP.Domain;
using AutoMapper;
using RJP.Application.DTOs;
using RJP.Application.Contracts.Persistence;

namespace RJP.Application.Features.Accounts.Queries
{

    public class GetAccountByIdQuery : IRequest<AccountDto>
    {
        public int Id { get; set; }
        public class GetAccountByIdQueryHandler : IRequestHandler<GetAccountByIdQuery, AccountDto>
        {
            private readonly IAccountRepository _accountRepository;
            private readonly IMapper _mapper;
            public GetAccountByIdQueryHandler(IAccountRepository accountRepository, IMapper mapper)
            {
                _accountRepository = accountRepository;
                _mapper = mapper;
            }

            public async Task<AccountDto> Handle(GetAccountByIdQuery query, CancellationToken cancellationToken)
            {
                var account = await _accountRepository.Get(query.Id);
                return _mapper.Map<AccountDto>(account);
            }
        }

    }
}
