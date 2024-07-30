using FluentValidation;

namespace Application.Features.Geolocations.Commands.Update;

public class UpdateGeolocationCommandValidator : AbstractValidator<UpdateGeolocationCommand>
{
    public UpdateGeolocationCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Country).NotEmpty();
        RuleFor(c => c.Admin1).NotEmpty();
        RuleFor(c => c.Admin2).NotEmpty();
        RuleFor(c => c.Latitude).NotEmpty();
        RuleFor(c => c.Longitude).NotEmpty();
    }
}