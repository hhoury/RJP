using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using AutoMapper;
using RJP.Application.DTOs;
using RJP.Application.Contracts.Persistence;

namespace RJP.Application.Features.Accounts.Queries
{
    public class GetAllAccountsByCustomerIdQuery : IRequest<IEnumerable<AccountDto>>
    {
        public int CustomerId { get; set; }

        public class GetAllAccountsByCustomerIdHandler : IRequestHandler<GetAllAccountsByCustomerIdQuery, IEnumerable<AccountDto>>
        {

            private readonly IAccountRepository _accountRepository;
            private readonly IMapper _mapper;
            public GetAllAccountsByCustomerIdHandler(IAccountRepository accountRepository, IMapper mapper)
            {
                _accountRepository = accountRepository;
                _mapper = mapper;
            }
            public async Task<IEnumerable<AccountDto>> Handle(GetAllAccountsByCustomerIdQuery query, CancellationToken cancellationToken)
            {
                var accountsList = await _accountRepository.GetByCustomerId(query.CustomerId);
                return _mapper.Map<IEnumerable<AccountDto>>(accountsList);
            }

        }
    }
}
