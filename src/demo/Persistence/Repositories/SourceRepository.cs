using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class SourceRepository : EfRepositoryBase<Source, Guid, BaseDbContext>, ISourceRepository
{
    public SourceRepository(BaseDbContext context) : base(context)
    {
    }
}