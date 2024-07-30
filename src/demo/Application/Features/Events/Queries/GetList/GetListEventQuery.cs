using Application.Features.Events.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.Events.Constants.EventsOperationClaims;

namespace Application.Features.Events.Queries.GetList;

public class GetListEventQuery : IRequest<GetListResponse<GetListEventListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListEvents({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetEvents";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListEventQueryHandler : IRequestHandler<GetListEventQuery, GetListResponse<GetListEventListItemDto>>
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;

        public GetListEventQueryHandler(IEventRepository eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListEventListItemDto>> Handle(GetListEventQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Event> events = await _eventRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListEventListItemDto> response = _mapper.Map<GetListResponse<GetListEventListItemDto>>(events);
            return response;
        }
    }
}