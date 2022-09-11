using FluentValidation;
using RJP.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace RJP.Application.DTOs.Validators
{
    public class TransactionDtoValidator : AbstractValidator<TransactionDto>
    {
        private readonly IAccountRepository _accountRepository;
        public TransactionDtoValidator(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
            RuleFor(t => t.AccountId)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .GreaterThan(0)
                .MustAsync(async (id, token) =>
                {
                    var accountExist = await _accountRepository.Exists(id);
                    return !accountExist;
                })
                .WithMessage("{PropertyName} does not exist");
        }
    }
}
