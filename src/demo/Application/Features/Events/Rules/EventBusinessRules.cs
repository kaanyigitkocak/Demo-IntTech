using Application.Features.Events.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Events.Rules;

public class EventBusinessRules : BaseBusinessRules
{
    private readonly IEventRepository _eventRepository;
    private readonly ILocalizationService _localizationService;

    public EventBusinessRules(IEventRepository eventRepository, ILocalizationService localizationService)
    {
        _eventRepository = eventRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, EventsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task EventShouldExistWhenSelected(Event? eventEntity)
    {
        if (eventEntity == null)
            await throwBusinessException(EventsBusinessMessages.EventNotExists);
    }

    public async Task EventIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Event? eventEntity = await _eventRepository.GetAsync(
            predicate: e => e.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await EventShouldExistWhenSelected(eventEntity);
    }
}