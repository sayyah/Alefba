using Alefba.Application.DTOs;
using Alefba.Application.Features.Exchange.Requests.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alefba.Application.Validators
{
    public class CreateExchangeCommandValidator:AbstractValidator<CreateExchangeCommand>
    {
        public CreateExchangeCommandValidator()
        {
            RuleFor(x => x.DateTime)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .GreaterThan(DateTime.Now).WithMessage("{PropertyName} is not a valid date");

            RuleFor(x => x.Rate)
              .NotEmpty().WithMessage("{PropertyName} is required")
              .NotNull();

            RuleFor(x => x.Symbol)
              .NotEmpty().WithMessage("{PropertyName} is required")
              .NotNull();
        }
    }
}
