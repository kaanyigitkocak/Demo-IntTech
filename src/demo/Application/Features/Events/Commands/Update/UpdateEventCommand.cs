using Application.Features.Events.Constants;
using Application.Features.Events.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;

using static Application.Features.Events.Constants.EventsOperationClaims;

namespace Application.Features.Events.Commands.Update;

public class UpdateEventCommand : IRequest<UpdatedEventResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public EventType EventType { get; set; }
    public Guid Actor1Id { get; set; }
    public Guid? Actor2Id { get; set; }
    public Guid GeolocationId { get; set; }
    public Guid SourceId { get; set; }
    public string Description { get; set; }
    public int Fatalities { get; set; }

    public string[] Roles => [Admin, Write, EventsOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetEvents"];

    public class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand, UpdatedEventResponse>
    {
        private readonly IMapper _mapper;
        private readonly IEventRepository _eventRepository;
        private readonly EventBusinessRules _eventBusinessRules;

        public UpdateEventCommandHandler(IMapper mapper, IEventRepository eventRepository,
                                         EventBusinessRules eventBusinessRules)
        {
            _mapper = mapper;
            _eventRepository = eventRepository;
            _eventBusinessRules = eventBusinessRules;
        }

        public async Task<UpdatedEventResponse> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
        {
            Event? eventEntity = await _eventRepository.GetAsync(predicate: e => e.Id == request.Id, cancellationToken: cancellationToken);
            await _eventBusinessRules.EventShouldExistWhenSelected(eventEntity);
            eventEntity = _mapper.Map(request, eventEntity);

            await _eventRepository.UpdateAsync(eventEntity!);

            UpdatedEventResponse response = _mapper.Map<UpdatedEventResponse>(eventEntity);
            return response;
        }
    }
}