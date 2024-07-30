using Application.Features.Geolocations.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Geolocations;

public class GeolocationManager : IGeolocationService
{
    private readonly IGeolocationRepository _geolocationRepository;
    private readonly GeolocationBusinessRules _geolocationBusinessRules;

    public GeolocationManager(IGeolocationRepository geolocationRepository, GeolocationBusinessRules geolocationBusinessRules)
    {
        _geolocationRepository = geolocationRepository;
        _geolocationBusinessRules = geolocationBusinessRules;
    }

    public async Task<Geolocation?> GetAsync(
        Expression<Func<Geolocation, bool>> predicate,
        Func<IQueryable<Geolocation>, IIncludableQueryable<Geolocation, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Geolocation? geolocation = await _geolocationRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return geolocation;
    }

    public async Task<IPaginate<Geolocation>?> GetListAsync(
        Expression<Func<Geolocation, bool>>? predicate = null,
        Func<IQueryable<Geolocation>, IOrderedQueryable<Geolocation>>? orderBy = null,
        Func<IQueryable<Geolocation>, IIncludableQueryable<Geolocation, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Geolocation> geolocationList = await _geolocationRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return geolocationList;
    }

    public async Task<Geolocation> AddAsync(Geolocation geolocation)
    {
        Geolocation addedGeolocation = await _geolocationRepository.AddAsync(geolocation);

        return addedGeolocation;
    }

    public async Task<Geolocation> UpdateAsync(Geolocation geolocation)
    {
        Geolocation updatedGeolocation = await _geolocationRepository.UpdateAsync(geolocation);

        return updatedGeolocation;
    }

    public async Task<Geolocation> DeleteAsync(Geolocation geolocation, bool permanent = false)
    {
        Geolocation deletedGeolocation = await _geolocationRepository.DeleteAsync(geolocation);

        return deletedGeolocation;
    }
}
