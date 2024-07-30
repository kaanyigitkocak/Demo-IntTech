using NArchitecture.Core.Application.Responses;

namespace Application.Features.Geolocations.Commands.Delete;

public class DeletedGeolocationResponse : IResponse
{
    public Guid Id { get; set; }
}