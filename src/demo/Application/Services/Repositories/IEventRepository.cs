using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IEventRepository : IAsyncRepository<Event, Guid>, IRepository<Event, Guid>
{
}