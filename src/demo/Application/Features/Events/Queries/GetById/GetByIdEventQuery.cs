using Application.Features.Events.Constants;
using Application.Features.Events.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Events.Constants.EventsOperationClaims;

namespace Application.Features.Events.Queries.GetById;

public class GetByIdEventQuery : IRequest<GetByIdEventResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdEventQueryHandler : IRequestHandler<GetByIdEventQuery, GetByIdEventResponse>
    {
        private readonly IMapper _mapper;
        private readonly IEventRepository _eventRepository;
        private readonly EventBusinessRules _eventBusinessRules;

        public GetByIdEventQueryHandler(IMapper mapper, IEventRepository eventRepository, EventBusinessRules eventBusinessRules)
        {
            _mapper = mapper;
            _eventRepository = eventRepository;
            _eventBusinessRules = eventBusinessRules;
        }

        public async Task<GetByIdEventResponse> Handle(GetByIdEventQuery request, CancellationToken cancellationToken)
        {
            Event? eventEntity = await _eventRepository.GetAsync(predicate: e => e.Id == request.Id, cancellationToken: cancellationToken);
            await _eventBusinessRules.EventShouldExistWhenSelected(eventEntity);

            GetByIdEventResponse response = _mapper.Map<GetByIdEventResponse>(eventEntity);
            return response;
        }
    }
}