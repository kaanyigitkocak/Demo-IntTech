using Application.Features.Actors.Commands.Create;
using Application.Features.Actors.Commands.Delete;
using Application.Features.Actors.Commands.Update;
using Application.Features.Actors.Queries.GetById;
using Application.Features.Actors.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Actors.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Actor, CreateActorCommand>().ReverseMap();
        CreateMap<Actor, CreatedActorResponse>().ReverseMap();
        CreateMap<Actor, UpdateActorCommand>().ReverseMap();
        CreateMap<Actor, UpdatedActorResponse>().ReverseMap();
        CreateMap<Actor, DeleteActorCommand>().ReverseMap();
        CreateMap<Actor, DeletedActorResponse>().ReverseMap();
        CreateMap<Actor, GetByIdActorResponse>().ReverseMap();
        CreateMap<Actor, GetListActorListItemDto>().ReverseMap();
        CreateMap<IPaginate<Actor>, GetListResponse<GetListActorListItemDto>>().ReverseMap();
    }
}