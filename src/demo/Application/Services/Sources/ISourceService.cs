using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Sources;

public interface ISourceService
{
    Task<Source?> GetAsync(
        Expression<Func<Source, bool>> predicate,
        Func<IQueryable<Source>, IIncludableQueryable<Source, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Source>?> GetListAsync(
        Expression<Func<Source, bool>>? predicate = null,
        Func<IQueryable<Source>, IOrderedQueryable<Source>>? orderBy = null,
        Func<IQueryable<Source>, IIncludableQueryable<Source, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Source> AddAsync(Source source);
    Task<Source> UpdateAsync(Source source);
    Task<Source> DeleteAsync(Source source, bool permanent = false);
}
