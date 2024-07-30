using Application.Features.Events.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Events;

public class EventManager : IEventService
{
    private readonly IEventRepository _eventRepository;
    private readonly EventBusinessRules _eventBusinessRules;

    public EventManager(IEventRepository eventRepository, EventBusinessRules eventBusinessRules)
    {
        _eventRepository = eventRepository;
        _eventBusinessRules = eventBusinessRules;
    }

    public async Task<Event?> GetAsync(
        Expression<Func<Event, bool>> predicate,
        Func<IQueryable<Event>, IIncludableQueryable<Event, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Event? eventEntity = await _eventRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return eventEntity;
    }

    public async Task<IPaginate<Event>?> GetListAsync(
        Expression<Func<Event, bool>>? predicate = null,
        Func<IQueryable<Event>, IOrderedQueryable<Event>>? orderBy = null,
        Func<IQueryable<Event>, IIncludableQueryable<Event, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Event> eventList = await _eventRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return eventList;
    }

    public async Task<Event> AddAsync(Event eventEntity)
    {
        Event addedEvent = await _eventRepository.AddAsync(eventEntity);

        return addedEvent;
    }

    public async Task<Event> UpdateAsync(Event eventEntity)
    {
        Event updatedEvent = await _eventRepository.UpdateAsync(eventEntity);

        return updatedEvent;
    }

    public async Task<Event> DeleteAsync(Event eventEntity, bool permanent = false)
    {
        Event deletedEvent = await _eventRepository.DeleteAsync(eventEntity);

        return deletedEvent;
    }
}
