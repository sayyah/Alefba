using Alefba.Application.Queries;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alefba.Application.Validators
{
    public class GetExchangeAverageInSpecificDateRequestValidator: AbstractValidator<GetExchangeAverageInSpecificDateRequest>
    {
        public GetExchangeAverageInSpecificDateRequestValidator()
        {
            RuleFor(x => x.startDateTime)
                .LessThan(p => p.endDateTime)
                .WithMessage("{PropertyName} must be before {comparisonValue}");
        }
    }
}
