using Application.Features.Geolocations.Constants;
using Application.Features.Geolocations.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Geolocations.Commands.Delete;

public class DeleteGeolocationCommand : IRequest<DeletedGeolocationResponse>
{
    public Guid Id { get; set; }

    public class DeleteGeolocationCommandHandler : IRequestHandler<DeleteGeolocationCommand, DeletedGeolocationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IGeolocationRepository _geolocationRepository;
        private readonly GeolocationBusinessRules _geolocationBusinessRules;

        public DeleteGeolocationCommandHandler(IMapper mapper, IGeolocationRepository geolocationRepository,
                                         GeolocationBusinessRules geolocationBusinessRules)
        {
            _mapper = mapper;
            _geolocationRepository = geolocationRepository;
            _geolocationBusinessRules = geolocationBusinessRules;
        }

        public async Task<DeletedGeolocationResponse> Handle(DeleteGeolocationCommand request, CancellationToken cancellationToken)
        {
            Geolocation? geolocation = await _geolocationRepository.GetAsync(predicate: g => g.Id == request.Id, cancellationToken: cancellationToken);
            await _geolocationBusinessRules.GeolocationShouldExistWhenSelected(geolocation);

            await _geolocationRepository.DeleteAsync(geolocation!);

            DeletedGeolocationResponse response = _mapper.Map<DeletedGeolocationResponse>(geolocation);
            return response;
        }
    }
}