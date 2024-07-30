using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class DenemeRepository : EfRepositoryBase<Deneme, Guid, BaseDbContext>, IDenemeRepository
{
    public DenemeRepository(BaseDbContext context) : base(context)
    {
    }
}