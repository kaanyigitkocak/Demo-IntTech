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
using NArchitecture.Core.Persistence.Dynamic;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Events.Queries.GetListByDynamic;

public class GetListByDynamicEventQuery : IRequest<GetListResponse<GetListByDynamicEventListDto>>
{ 
        public PageRequest PageRequest { get; set; }
        public DynamicQuery DynamicQuery { get; set; }

    public class GetListByDynamicEventQueryHandler : IRequestHandler<GetListByDynamicEventQuery, GetListResponse<GetListByDynamicEventListDto>>
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;

        public GetListByDynamicEventQueryHandler(IEventRepository eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListByDynamicEventListDto>> Handle(GetListByDynamicEventQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Event> events = await _eventRepository.GetListByDynamicAsync(
                request.DynamicQuery,
                include: e => e.Include(e => e.Actor1).Include(e => e.Actor2).Include(e => e.Geolocation).Include(e => e.Source),
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListByDynamicEventListDto> response = _mapper.Map<GetListResponse<GetListByDynamicEventListDto>>(events);
            return response;
        }
    }
}