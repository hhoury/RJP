using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using RJP.Domain;
using AutoMapper;
using RJP.Application.Contracts.Persistence;

namespace RJP.Application.Features.Customers.Queries
{
    public class GetAllCustomersQuery : IRequest<IEnumerable<Customer>>
    {
        public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, IEnumerable<Customer>>
        {
            private readonly ICustomerRepository _customerRepository;
            private readonly IMapper _mapper;
            public GetAllCustomersQueryHandler(ICustomerRepository customerRepository,IMapper mapper)
            {
                _customerRepository = customerRepository;
                _mapper = mapper;
            }
            public async Task<IEnumerable<Customer>> Handle(GetAllCustomersQuery query, CancellationToken cancellationToken)
            {
                var customersList = await _customerRepository.GetAll();

                return _mapper.Map<IEnumerable<Customer>>(customersList);
            }
        }
    }

}
