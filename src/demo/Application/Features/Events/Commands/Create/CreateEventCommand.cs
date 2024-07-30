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

namespace Application.Features.Events.Commands.Create;

public class CreateEventCommand : IRequest<CreatedEventResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public DateTime Date { get; set; }
    public EventType EventType { get; set; }
    public Guid Actor1Id { get; set; }
    public Guid? Actor2Id { get; set; }
    public Guid GeolocationId { get; set; }
    public Guid SourceId { get; set; }
    public string Description { get; set; }
    public int Fatalities { get; set; }

    public string[] Roles => [Admin, Write, EventsOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetEvents"];

    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, CreatedEventResponse>
    {
        private readonly IMapper _mapper;
        private readonly IEventRepository _eventRepository;
        private readonly EventBusinessRules _eventBusinessRules;

        public CreateEventCommandHandler(IMapper mapper, IEventRepository eventRepository,
                                         EventBusinessRules eventBusinessRules)
        {
            _mapper = mapper;
            _eventRepository = eventRepository;
            _eventBusinessRules = eventBusinessRules;
        }

        public async Task<CreatedEventResponse> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            Event eventEntity = _mapper.Map<Event>(request);

            await _eventRepository.AddAsync(eventEntity);

            CreatedEventResponse response = _mapper.Map<CreatedEventResponse>(eventEntity);
            return response;
        }
    }
}