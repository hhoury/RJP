using MediatR;
using System.Threading.Tasks;
using System.Threading;
using AutoMapper;
using RJP.Application.DTOs;
using RJP.Application.Contracts.Persistence;

namespace RJP.Application.Features.Customers.Queries
{
    public class GetCustomerByIdQuery : IRequest<CustomerDto>
    {
        public int Id { get; set; }
        public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, CustomerDto>
        {
            private readonly ICustomerRepository _customerRepository;
            private readonly IMapper _mapper;
            public GetCustomerByIdQueryHandler(ICustomerRepository customerRepository,IMapper mapper)
            {
                _customerRepository = customerRepository;
                _mapper = mapper;
            }

            public async Task<CustomerDto> Handle(GetCustomerByIdQuery query, CancellationToken cancellationToken)
            {
                var customer = await _customerRepository.Get(query.Id);
                if (customer == null) return null;
                return _mapper.Map<CustomerDto>(customer);
            }
        }
    }
}
