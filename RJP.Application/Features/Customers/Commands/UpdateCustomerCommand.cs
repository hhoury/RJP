using MediatR;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;
using RJP.Domain;
using AutoMapper;
using RJP.Application.DTOs;
using RJP.Application.Contracts.Persistence;

namespace RJP.Application.Features.Customers.Commands
{
    public class UpdateCustomerCommand : IRequest<Unit>
    {
        public CustomerDto CustomerDto { get; set; }

        public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, Unit>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;
            public UpdateCustomerCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(UpdateCustomerCommand command, CancellationToken cancellationToken)
            {
                var customer = await _unitOfWork.CustomerRepository.Get(command.CustomerDto.Id);
                 _mapper.Map(command.CustomerDto, customer);
                await _unitOfWork.CustomerRepository.Update(customer);
                await _unitOfWork.Save();
                return Unit.Value;
            }
        }

    }

}
