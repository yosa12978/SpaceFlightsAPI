using FluentValidation;
using SpaceFlights.API.Dtos.Impl;
using SpaceFlights.Core.Domain;
namespace SpaceFlights.API.Validators;

public class FlightCreateDtoValidator : AbstractValidator<FlightCreateDto>
{
    public FlightCreateDtoValidator() 
    {
        RuleFor(x => x.Rocket).NotEmpty().NotNull().WithMessage("Rocket is required");
        RuleFor(x => x.Mission).NotEmpty().NotNull().WithMessage("Mission is required");
        RuleFor(x => x.Desc).NotEmpty().NotNull().WithMessage("Desc is required");
        RuleFor(x => x.Date).NotEmpty().NotNull().WithMessage("Date is required");
    }
}