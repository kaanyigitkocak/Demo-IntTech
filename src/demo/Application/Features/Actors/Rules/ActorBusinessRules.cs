using Application.Features.Actors.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Actors.Rules;

public class ActorBusinessRules : BaseBusinessRules
{
    private readonly IActorRepository _actorRepository;
    private readonly ILocalizationService _localizationService;

    public ActorBusinessRules(IActorRepository actorRepository, ILocalizationService localizationService)
    {
        _actorRepository = actorRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, ActorsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task ActorShouldExistWhenSelected(Actor? actor)
    {
        if (actor == null)
            await throwBusinessException(ActorsBusinessMessages.ActorNotExists);
    }

    public async Task ActorIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Actor? actor = await _actorRepository.GetAsync(
            predicate: a => a.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ActorShouldExistWhenSelected(actor);
    }
}