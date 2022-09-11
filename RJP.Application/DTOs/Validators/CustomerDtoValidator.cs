using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace RJP.Application.DTOs.Validators
{
    public class CustomerDtoValidator : AbstractValidator<CustomerDto>
    {
        public CustomerDtoValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull();
            RuleFor(c => c.Surname)
               .NotEmpty().WithMessage("{PropertyName} is required")
               .NotNull();
        }
    }
}
