using Application.Features.Sources.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Sources;

public class SourceManager : ISourceService
{
    private readonly ISourceRepository _sourceRepository;
    private readonly SourceBusinessRules _sourceBusinessRules;

    public SourceManager(ISourceRepository sourceRepository, SourceBusinessRules sourceBusinessRules)
    {
        _sourceRepository = sourceRepository;
        _sourceBusinessRules = sourceBusinessRules;
    }

    public async Task<Source?> GetAsync(
        Expression<Func<Source, bool>> predicate,
        Func<IQueryable<Source>, IIncludableQueryable<Source, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Source? source = await _sourceRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return source;
    }

    public async Task<IPaginate<Source>?> GetListAsync(
        Expression<Func<Source, bool>>? predicate = null,
        Func<IQueryable<Source>, IOrderedQueryable<Source>>? orderBy = null,
        Func<IQueryable<Source>, IIncludableQueryable<Source, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Source> sourceList = await _sourceRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return sourceList;
    }

    public async Task<Source> AddAsync(Source source)
    {
        Source addedSource = await _sourceRepository.AddAsync(source);

        return addedSource;
    }

    public async Task<Source> UpdateAsync(Source source)
    {
        Source updatedSource = await _sourceRepository.UpdateAsync(source);

        return updatedSource;
    }

    public async Task<Source> DeleteAsync(Source source, bool permanent = false)
    {
        Source deletedSource = await _sourceRepository.DeleteAsync(source);

        return deletedSource;
    }
}
