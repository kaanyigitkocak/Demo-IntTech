using NArchitecture.Core.Application.Responses;

namespace Application.Features.Geolocations.Queries.GetById;

public class GetByIdGeolocationResponse : IResponse
{
    public Guid Id { get; set; }
    public string Country { get; set; }
    public string Admin1 { get; set; }
    public string Admin2 { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}