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

namespace Application.Features.Events.Commands.Delete;

public class DeleteEventCommand : IRequest<DeletedEventResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, EventsOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetEvents"];

    public class DeleteEventCommandHandler : IRequestHandler<DeleteEventCommand, DeletedEventResponse>
    {
        private readonly IMapper _mapper;
        private readonly IEventRepository _eventRepository;
        private readonly EventBusinessRules _eventBusinessRules;

        public DeleteEventCommandHandler(IMapper mapper, IEventRepository eventRepository,
                                         EventBusinessRules eventBusinessRules)
        {
            _mapper = mapper;
            _eventRepository = eventRepository;
            _eventBusinessRules = eventBusinessRules;
        }

        public async Task<DeletedEventResponse> Handle(DeleteEventCommand request, CancellationToken cancellationToken)
        {
            Event? eventEntity = await _eventRepository.GetAsync(predicate: e => e.Id == request.Id, cancellationToken: cancellationToken);
            await _eventBusinessRules.EventShouldExistWhenSelected(eventEntity);

            await _eventRepository.DeleteAsync(eventEntity!);

            DeletedEventResponse response = _mapper.Map<DeletedEventResponse>(eventEntity);
            return response;
        }
    }
}