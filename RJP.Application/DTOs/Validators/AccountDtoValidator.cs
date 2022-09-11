using FluentValidation;
using RJP.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace RJP.Application.DTOs.Validators
{
    public class AccountDtoValidator : AbstractValidator<AccountDto>
    {
        private readonly ICustomerRepository _customerRepository;

        public AccountDtoValidator(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
            RuleFor(a => a.CustomerId)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .GreaterThan(0)
                .MustAsync(async (id, token) =>
                {
                    var accountExist = await _customerRepository.Exists(id);
                    return accountExist;
                })
                .WithMessage("{PropertyName} does not exist"); ;
            RuleFor(a => a.Balance)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .GreaterThanOrEqualTo(0).WithMessage("{PropertyName} can not be negative");

        }
    }
}
