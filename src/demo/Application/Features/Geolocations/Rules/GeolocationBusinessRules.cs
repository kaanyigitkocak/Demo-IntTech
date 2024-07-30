using Application.Features.Geolocations.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Geolocations.Rules;

public class GeolocationBusinessRules : BaseBusinessRules
{
    private readonly IGeolocationRepository _geolocationRepository;
    private readonly ILocalizationService _localizationService;

    public GeolocationBusinessRules(IGeolocationRepository geolocationRepository, ILocalizationService localizationService)
    {
        _geolocationRepository = geolocationRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, GeolocationsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task GeolocationShouldExistWhenSelected(Geolocation? geolocation)
    {
        if (geolocation == null)
            await throwBusinessException(GeolocationsBusinessMessages.GeolocationNotExists);
    }

    public async Task GeolocationIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Geolocation? geolocation = await _geolocationRepository.GetAsync(
            predicate: g => g.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await GeolocationShouldExistWhenSelected(geolocation);
    }
}