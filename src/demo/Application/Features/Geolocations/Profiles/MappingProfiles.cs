using Application.Features.Geolocations.Commands.Create;
using Application.Features.Geolocations.Commands.Delete;
using Application.Features.Geolocations.Commands.Update;
using Application.Features.Geolocations.Queries.GetById;
using Application.Features.Geolocations.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Geolocations.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Geolocation, CreateGeolocationCommand>().ReverseMap();
        CreateMap<Geolocation, CreatedGeolocationResponse>().ReverseMap();
        CreateMap<Geolocation, UpdateGeolocationCommand>().ReverseMap();
        CreateMap<Geolocation, UpdatedGeolocationResponse>().ReverseMap();
        CreateMap<Geolocation, DeleteGeolocationCommand>().ReverseMap();
        CreateMap<Geolocation, DeletedGeolocationResponse>().ReverseMap();
        CreateMap<Geolocation, GetByIdGeolocationResponse>().ReverseMap();
        CreateMap<Geolocation, GetListGeolocationListItemDto>().ReverseMap();
        CreateMap<IPaginate<Geolocation>, GetListResponse<GetListGeolocationListItemDto>>().ReverseMap();
    }
}