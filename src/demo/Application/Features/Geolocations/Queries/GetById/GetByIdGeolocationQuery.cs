using Application.Features.Geolocations.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Geolocations.Queries.GetById;

public class GetByIdGeolocationQuery : IRequest<GetByIdGeolocationResponse>
{
    public Guid Id { get; set; }

    public class GetByIdGeolocationQueryHandler : IRequestHandler<GetByIdGeolocationQuery, GetByIdGeolocationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IGeolocationRepository _geolocationRepository;
        private readonly GeolocationBusinessRules _geolocationBusinessRules;

        public GetByIdGeolocationQueryHandler(IMapper mapper, IGeolocationRepository geolocationRepository, GeolocationBusinessRules geolocationBusinessRules)
        {
            _mapper = mapper;
            _geolocationRepository = geolocationRepository;
            _geolocationBusinessRules = geolocationBusinessRules;
        }

        public async Task<GetByIdGeolocationResponse> Handle(GetByIdGeolocationQuery request, CancellationToken cancellationToken)
        {
            Geolocation? geolocation = await _geolocationRepository.GetAsync(predicate: g => g.Id == request.Id, cancellationToken: cancellationToken);
            await _geolocationBusinessRules.GeolocationShouldExistWhenSelected(geolocation);

            GetByIdGeolocationResponse response = _mapper.Map<GetByIdGeolocationResponse>(geolocation);
            return response;
        }
    }
}