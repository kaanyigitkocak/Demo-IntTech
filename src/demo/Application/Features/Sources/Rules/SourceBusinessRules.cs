using Application.Features.Sources.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Sources.Rules;

public class SourceBusinessRules : BaseBusinessRules
{
    private readonly ISourceRepository _sourceRepository;
    private readonly ILocalizationService _localizationService;

    public SourceBusinessRules(ISourceRepository sourceRepository, ILocalizationService localizationService)
    {
        _sourceRepository = sourceRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, SourcesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task SourceShouldExistWhenSelected(Source? source)
    {
        if (source == null)
            await throwBusinessException(SourcesBusinessMessages.SourceNotExists);
    }

    public async Task SourceIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Source? source = await _sourceRepository.GetAsync(
            predicate: s => s.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await SourceShouldExistWhenSelected(source);
    }
}