using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using RJP.Application.DTOs;
using AutoMapper;
using RJP.Application.Contracts.Persistence;

namespace RJP.Application.Features.Accounts.Queries
{
    public class GetAllAccountsQuery : IRequest<IEnumerable<AccountDto>>
    {

        public class GetAllAccountsQueryHandler : IRequestHandler<GetAllAccountsQuery, IEnumerable<AccountDto>>
        {
            private readonly IAccountRepository _accountRepository;
            private readonly IMapper _mapper;

            public GetAllAccountsQueryHandler(IAccountRepository accountRepository, IMapper mapper)
            {
                _accountRepository = accountRepository;
                _mapper = mapper;
            }
            public async Task<IEnumerable<AccountDto>> Handle(GetAllAccountsQuery query, CancellationToken cancellationToken)
            {
                var accountsList = await _accountRepository.GetAll();
                return _mapper.Map<IEnumerable<AccountDto>>(accountsList);
            }

        }
    }
}
