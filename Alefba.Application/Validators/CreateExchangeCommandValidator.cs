using Alefba.Application.Commands;
using FluentValidation;

namespace Alefba.Application.Validators
{
    public class CreateExchangeCommandValidator : AbstractValidator<CreateExchangeCommand>
    {
        public CreateExchangeCommandValidator()
        {
            RuleFor(x => x.DateTime)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .GreaterThan(DateTime.Now.AddDays(-1)).WithMessage("{PropertyName} is not a valid date");

            RuleFor(x => x.Rate)
              .NotEmpty().WithMessage("{PropertyName} is required")
              .NotNull();

            RuleFor(x => x.Symbol)
              .NotEmpty().WithMessage("{PropertyName} is required")
              .NotNull();
        }
    }
}
