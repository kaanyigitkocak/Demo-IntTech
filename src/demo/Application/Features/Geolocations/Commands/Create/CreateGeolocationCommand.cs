using Application.Features.Geolocations.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Geolocations.Commands.Create;

public class CreateGeolocationCommand : IRequest<CreatedGeolocationResponse>
{
    public string Country { get; set; }
    public string Admin1 { get; set; }
    public string Admin2 { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }

    public class CreateGeolocationCommandHandler : IRequestHandler<CreateGeolocationCommand, CreatedGeolocationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IGeolocationRepository _geolocationRepository;
        private readonly GeolocationBusinessRules _geolocationBusinessRules;

        public CreateGeolocationCommandHandler(IMapper mapper, IGeolocationRepository geolocationRepository,
                                         GeolocationBusinessRules geolocationBusinessRules)
        {
            _mapper = mapper;
            _geolocationRepository = geolocationRepository;
            _geolocationBusinessRules = geolocationBusinessRules;
        }

        public async Task<CreatedGeolocationResponse> Handle(CreateGeolocationCommand request, CancellationToken cancellationToken)
        {
            Geolocation geolocation = _mapper.Map<Geolocation>(request);

            await _geolocationRepository.AddAsync(geolocation);

            CreatedGeolocationResponse response = _mapper.Map<CreatedGeolocationResponse>(geolocation);
            return response;
        }
    }
}