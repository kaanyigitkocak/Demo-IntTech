using Application.Features.Denemes.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Denemes.Rules;

public class DenemeBusinessRules : BaseBusinessRules
{
    private readonly IDenemeRepository _denemeRepository;
    private readonly ILocalizationService _localizationService;

    public DenemeBusinessRules(IDenemeRepository denemeRepository, ILocalizationService localizationService)
    {
        _denemeRepository = denemeRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, DenemesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task DenemeShouldExistWhenSelected(Deneme? deneme)
    {
        if (deneme == null)
            await throwBusinessException(DenemesBusinessMessages.DenemeNotExists);
    }

    public async Task DenemeIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Deneme? deneme = await _denemeRepository.GetAsync(
            predicate: d => d.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await DenemeShouldExistWhenSelected(deneme);
    }
}