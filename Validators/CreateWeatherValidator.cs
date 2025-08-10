using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using WeatherPresentAPI.Dtos;

namespace WeatherPresentAPI.Validators
{
    public class CreateWeatherValidator : AbstractValidator<CreateWeatherDto>
    {
        public CreateWeatherValidator()
        {
             RuleFor(x => x.LocationId).GreaterThan(0);
            RuleFor(x => x.Temperature).InclusiveBetween(-100, 100); 
            RuleFor(x => x.Pressure).GreaterThan(700);

        RuleFor(x => x.WindDirection)
            .IsInEnum().WithMessage("Invalid wind direction value. Example: North, NorthWest");

        RuleFor(x => x.WindSpeed)
            .IsInEnum().WithMessage("Invalid wind direction value. Example: Calm etc.");
        }
    }
}