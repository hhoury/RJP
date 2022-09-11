using MediatR;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;
using AutoMapper;
using RJP.Application.Contracts.Persistence;
using RJP.Application.Exceptions;
using RJP.Domain;

namespace RJP.Application.Features.Customers.Commands
{
    public class DeleteCustomerByIdCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public class DeleteCustomerByIdCommandHandler : IRequestHandler<DeleteCustomerByIdCommand, bool>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public DeleteCustomerByIdCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }
            public async Task<bool> Handle(DeleteCustomerByIdCommand command, CancellationToken cancellationToken)
            {
                var customer = await _unitOfWork.CustomerRepository.Get(command.Id);
                if(customer == null)
                {
                    throw new NotFoundException(nameof(Customer),command.Id);
                }
                await _unitOfWork.CustomerRepository.Delete(customer);
                await _unitOfWork.Save();
                return true;

            }
        }
    }

}
