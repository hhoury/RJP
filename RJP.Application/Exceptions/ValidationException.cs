using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace RJP.Application.Exceptions
{
    public class ValidationException : ApplicationException
    {
        public List<string> Errors { get; set; } = new List<string>();
        public ValidationException(ValidationResult validationResults)
        {
            foreach (var error in validationResults.Errors)
            {
                Errors.Add(error.ErrorMessage);
            }
        }
    }
}
