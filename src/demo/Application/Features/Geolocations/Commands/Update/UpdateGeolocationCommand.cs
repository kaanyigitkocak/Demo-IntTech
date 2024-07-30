using Application.Features.Geolocations.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Geolocations.Commands.Update;

public class UpdateGeolocationCommand : IRequest<UpdatedGeolocationResponse>
{
    public Guid Id { get; set; }
    public string Country { get; set; }
    public string Admin1 { get; set; }
    public string Admin2 { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }

    public class UpdateGeolocationCommandHandler : IRequestHandler<UpdateGeolocationCommand, UpdatedGeolocationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IGeolocationRepository _geolocationRepository;
        private readonly GeolocationBusinessRules _geolocationBusinessRules;

        public UpdateGeolocationCommandHandler(IMapper mapper, IGeolocationRepository geolocationRepository,
                                         GeolocationBusinessRules geolocationBusinessRules)
        {
            _mapper = mapper;
            _geolocationRepository = geolocationRepository;
            _geolocationBusinessRules = geolocationBusinessRules;
        }

        public async Task<UpdatedGeolocationResponse> Handle(UpdateGeolocationCommand request, CancellationToken cancellationToken)
        {
            Geolocation? geolocation = await _geolocationRepository.GetAsync(predicate: g => g.Id == request.Id, cancellationToken: cancellationToken);
            await _geolocationBusinessRules.GeolocationShouldExistWhenSelected(geolocation);
            geolocation = _mapper.Map(request, geolocation);

            await _geolocationRepository.UpdateAsync(geolocation!);

            UpdatedGeolocationResponse response = _mapper.Map<UpdatedGeolocationResponse>(geolocation);
            return response;
        }
    }
}