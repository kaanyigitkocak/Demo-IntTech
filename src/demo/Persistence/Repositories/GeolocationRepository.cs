using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class GeolocationRepository : EfRepositoryBase<Geolocation, Guid, BaseDbContext>, IGeolocationRepository
{
    public GeolocationRepository(BaseDbContext context) : base(context)
    {
    }
}