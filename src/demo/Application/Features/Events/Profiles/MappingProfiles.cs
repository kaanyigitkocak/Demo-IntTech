using Application.Features.Events.Commands.Create;
using Application.Features.Events.Commands.Delete;
using Application.Features.Events.Commands.Update;
using Application.Features.Events.Queries.GetById;
using Application.Features.Events.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;
using Application.Features.Events.Queries.GetListByDynamic;

namespace Application.Features.Events.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Event, CreateEventCommand>().ReverseMap();
        CreateMap<Event, CreatedEventResponse>().ReverseMap();
        CreateMap<Event, UpdateEventCommand>().ReverseMap();
        CreateMap<Event, UpdatedEventResponse>().ReverseMap();
        CreateMap<Event, DeleteEventCommand>().ReverseMap();
        CreateMap<Event, DeletedEventResponse>().ReverseMap();
        CreateMap<Event, GetByIdEventResponse>().ReverseMap();
        CreateMap<Event, GetListEventListItemDto>().ReverseMap();
        CreateMap<IPaginate<Event>, GetListResponse<GetListEventListItemDto>>().ReverseMap();
        CreateMap<Event, GetListByDynamicEventListDto>().ReverseMap();
        CreateMap<IPaginate<Event>, GetListResponse<GetListByDynamicEventListDto>>().ReverseMap();
        CreateMap<Actor, ActorDto>().ReverseMap();
        CreateMap<Geolocation, GeolocationDto>().ReverseMap();
        CreateMap<Source, SourceDto>().ReverseMap();
    }
}