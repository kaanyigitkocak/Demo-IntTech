using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Denemes;

public interface IDenemeService
{
    Task<Deneme?> GetAsync(
        Expression<Func<Deneme, bool>> predicate,
        Func<IQueryable<Deneme>, IIncludableQueryable<Deneme, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Deneme>?> GetListAsync(
        Expression<Func<Deneme, bool>>? predicate = null,
        Func<IQueryable<Deneme>, IOrderedQueryable<Deneme>>? orderBy = null,
        Func<IQueryable<Deneme>, IIncludableQueryable<Deneme, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Deneme> AddAsync(Deneme deneme);
    Task<Deneme> UpdateAsync(Deneme deneme);
    Task<Deneme> DeleteAsync(Deneme deneme, bool permanent = false);
}
