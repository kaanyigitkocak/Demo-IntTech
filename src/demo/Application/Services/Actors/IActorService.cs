using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Actors;

public interface IActorService
{
    Task<Actor?> GetAsync(
        Expression<Func<Actor, bool>> predicate,
        Func<IQueryable<Actor>, IIncludableQueryable<Actor, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Actor>?> GetListAsync(
        Expression<Func<Actor, bool>>? predicate = null,
        Func<IQueryable<Actor>, IOrderedQueryable<Actor>>? orderBy = null,
        Func<IQueryable<Actor>, IIncludableQueryable<Actor, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Actor> AddAsync(Actor actor);
    Task<Actor> UpdateAsync(Actor actor);
    Task<Actor> DeleteAsync(Actor actor, bool permanent = false);
}
