using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ISourceRepository : IAsyncRepository<Source, Guid>, IRepository<Source, Guid>
{
}