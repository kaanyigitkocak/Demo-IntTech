using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class EventRepository : EfRepositoryBase<Event, Guid, BaseDbContext>, IEventRepository
{
    public EventRepository(BaseDbContext context) : base(context)
    {
    }
}