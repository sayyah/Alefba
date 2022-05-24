using Alefba.Application.Queries;
using FluentValidation;

namespace Alefba.Application.Validators
{
    public class GetExchangeAverageInSpecificDateRequestValidator : AbstractValidator<GetExchangeAverageInSpecificDateRequest>
    {
        public GetExchangeAverageInSpecificDateRequestValidator()
        {
            RuleFor(x => x.startDateTime)
                .LessThan(p => p.endDateTime)
                .WithMessage("{PropertyName} must be before {comparisonValue}");
        }
    }
}
