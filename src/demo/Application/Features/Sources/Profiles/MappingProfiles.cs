using Application.Features.Sources.Commands.Create;
using Application.Features.Sources.Commands.Delete;
using Application.Features.Sources.Commands.Update;
using Application.Features.Sources.Queries.GetById;
using Application.Features.Sources.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Sources.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Source, CreateSourceCommand>().ReverseMap();
        CreateMap<Source, CreatedSourceResponse>().ReverseMap();
        CreateMap<Source, UpdateSourceCommand>().ReverseMap();
        CreateMap<Source, UpdatedSourceResponse>().ReverseMap();
        CreateMap<Source, DeleteSourceCommand>().ReverseMap();
        CreateMap<Source, DeletedSourceResponse>().ReverseMap();
        CreateMap<Source, GetByIdSourceResponse>().ReverseMap();
        CreateMap<Source, GetListSourceListItemDto>().ReverseMap();
        CreateMap<IPaginate<Source>, GetListResponse<GetListSourceListItemDto>>().ReverseMap();
    }
}