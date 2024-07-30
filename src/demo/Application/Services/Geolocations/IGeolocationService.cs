using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Geolocations;

public interface IGeolocationService
{
    Task<Geolocation?> GetAsync(
        Expression<Func<Geolocation, bool>> predicate,
        Func<IQueryable<Geolocation>, IIncludableQueryable<Geolocation, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Geolocation>?> GetListAsync(
        Expression<Func<Geolocation, bool>>? predicate = null,
        Func<IQueryable<Geolocation>, IOrderedQueryable<Geolocation>>? orderBy = null,
        Func<IQueryable<Geolocation>, IIncludableQueryable<Geolocation, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Geolocation> AddAsync(Geolocation geolocation);
    Task<Geolocation> UpdateAsync(Geolocation geolocation);
    Task<Geolocation> DeleteAsync(Geolocation geolocation, bool permanent = false);
}
