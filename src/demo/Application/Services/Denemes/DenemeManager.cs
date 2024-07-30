using Application.Features.Denemes.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Denemes;

public class DenemeManager : IDenemeService
{
    private readonly IDenemeRepository _denemeRepository;
    private readonly DenemeBusinessRules _denemeBusinessRules;

    public DenemeManager(IDenemeRepository denemeRepository, DenemeBusinessRules denemeBusinessRules)
    {
        _denemeRepository = denemeRepository;
        _denemeBusinessRules = denemeBusinessRules;
    }

    public async Task<Deneme?> GetAsync(
        Expression<Func<Deneme, bool>> predicate,
        Func<IQueryable<Deneme>, IIncludableQueryable<Deneme, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Deneme? deneme = await _denemeRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return deneme;
    }

    public async Task<IPaginate<Deneme>?> GetListAsync(
        Expression<Func<Deneme, bool>>? predicate = null,
        Func<IQueryable<Deneme>, IOrderedQueryable<Deneme>>? orderBy = null,
        Func<IQueryable<Deneme>, IIncludableQueryable<Deneme, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Deneme> denemeList = await _denemeRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return denemeList;
    }

    public async Task<Deneme> AddAsync(Deneme deneme)
    {
        Deneme addedDeneme = await _denemeRepository.AddAsync(deneme);

        return addedDeneme;
    }

    public async Task<Deneme> UpdateAsync(Deneme deneme)
    {
        Deneme updatedDeneme = await _denemeRepository.UpdateAsync(deneme);

        return updatedDeneme;
    }

    public async Task<Deneme> DeleteAsync(Deneme deneme, bool permanent = false)
    {
        Deneme deletedDeneme = await _denemeRepository.DeleteAsync(deneme);

        return deletedDeneme;
    }
}
