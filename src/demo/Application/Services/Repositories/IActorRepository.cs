using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IActorRepository : IAsyncRepository<Actor, Guid>, IRepository<Actor, Guid>
{
}