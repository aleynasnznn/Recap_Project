using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    class CarDetailDtoValidator : AbstractValidator<CarDetailDto>
    {
        public CarDetailDtoValidator()
        {
            RuleFor(p => p.BrandName).MinimumLength(2);
            RuleFor(p => p.DailyPrice).GreaterThan(0);
        }
    }
}
