using MediatR;
using System.Threading.Tasks;
using System.Threading;
using RJP.Domain;
using AutoMapper;
using RJP.Application.DTOs;
using RJP.Application.DTOs.Validators;
using System;
using RJP.Application.Contracts.Persistence;
using RJP.Application.Exceptions;
using RJP.Application.Responses;
using System.Linq;

namespace RJP.Application.Features.Customers.Commands
{

    public class CreateCustomerCommand : IRequest<BaseCommandResponse>
    {
        public CustomerDto CustomerDto{ get; set; }

        public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, BaseCommandResponse>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;
            public CreateCustomerCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }
            public async Task<BaseCommandResponse> Handle(CreateCustomerCommand command, CancellationToken cancellationToken)
            {
                var response = new BaseCommandResponse();
                var validator = new CustomerDtoValidator();
                var validationResult = await validator.ValidateAsync(command.CustomerDto);

                if (!validationResult.IsValid)
                {
                    response.Success = false;
                    response.Message = "Customer Creation Failed";
                    response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
                    throw new ValidationException(validationResult);
                }
                else
                {
                    var customer = _mapper.Map<Customer>(command.CustomerDto);
                    customer = await _unitOfWork.CustomerRepository.Add(customer);
                    await _unitOfWork.Save();
                    response.Success = true;
                    response.Message = "Customer Creation Successful";
                    
                }
                return response;
            }
        }
    }


}
