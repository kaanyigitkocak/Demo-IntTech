using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Geolocations.Queries.GetList;

public class GetListGeolocationQuery : IRequest<GetListResponse<GetListGeolocationListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListGeolocationQueryHandler : IRequestHandler<GetListGeolocationQuery, GetListResponse<GetListGeolocationListItemDto>>
    {
        private readonly IGeolocationRepository _geolocationRepository;
        private readonly IMapper _mapper;

        public GetListGeolocationQueryHandler(IGeolocationRepository geolocationRepository, IMapper mapper)
        {
            _geolocationRepository = geolocationRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListGeolocationListItemDto>> Handle(GetListGeolocationQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Geolocation> geolocations = await _geolocationRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListGeolocationListItemDto> response = _mapper.Map<GetListResponse<GetListGeolocationListItemDto>>(geolocations);
            return response;
        }
    }
}