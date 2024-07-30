using Application.Features.Actors.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Actors;

public class ActorManager : IActorService
{
    private readonly IActorRepository _actorRepository;
    private readonly ActorBusinessRules _actorBusinessRules;

    public ActorManager(IActorRepository actorRepository, ActorBusinessRules actorBusinessRules)
    {
        _actorRepository = actorRepository;
        _actorBusinessRules = actorBusinessRules;
    }

    public async Task<Actor?> GetAsync(
        Expression<Func<Actor, bool>> predicate,
        Func<IQueryable<Actor>, IIncludableQueryable<Actor, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Actor? actor = await _actorRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return actor;
    }

    public async Task<IPaginate<Actor>?> GetListAsync(
        Expression<Func<Actor, bool>>? predicate = null,
        Func<IQueryable<Actor>, IOrderedQueryable<Actor>>? orderBy = null,
        Func<IQueryable<Actor>, IIncludableQueryable<Actor, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Actor> actorList = await _actorRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return actorList;
    }

    public async Task<Actor> AddAsync(Actor actor)
    {
        Actor addedActor = await _actorRepository.AddAsync(actor);

        return addedActor;
    }

    public async Task<Actor> UpdateAsync(Actor actor)
    {
        Actor updatedActor = await _actorRepository.UpdateAsync(actor);

        return updatedActor;
    }

    public async Task<Actor> DeleteAsync(Actor actor, bool permanent = false)
    {
        Actor deletedActor = await _actorRepository.DeleteAsync(actor);

        return deletedActor;
    }
}
