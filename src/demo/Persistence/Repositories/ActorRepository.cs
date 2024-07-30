using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ActorRepository : EfRepositoryBase<Actor, Guid, BaseDbContext>, IActorRepository
{
    public ActorRepository(BaseDbContext context) : base(context)
    {
    }
}