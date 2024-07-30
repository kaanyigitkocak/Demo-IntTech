using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Events;

public interface IEventService
{
    Task<Event?> GetAsync(
        Expression<Func<Event, bool>> predicate,
        Func<IQueryable<Event>, IIncludableQueryable<Event, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Event>?> GetListAsync(
        Expression<Func<Event, bool>>? predicate = null,
        Func<IQueryable<Event>, IOrderedQueryable<Event>>? orderBy = null,
        Func<IQueryable<Event>, IIncludableQueryable<Event, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Event> AddAsync(Event eventEntity);
    Task<Event> UpdateAsync(Event eventEntity);
    Task<Event> DeleteAsync(Event eventEntity, bool permanent = false);
}
