using Application.Features.Denemes.Commands.Create;
using Application.Features.Denemes.Commands.Delete;
using Application.Features.Denemes.Commands.Update;
using Application.Features.Denemes.Queries.GetById;
using Application.Features.Denemes.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Denemes.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Deneme, CreateDenemeCommand>().ReverseMap();
        CreateMap<Deneme, CreatedDenemeResponse>().ReverseMap();
        CreateMap<Deneme, UpdateDenemeCommand>().ReverseMap();
        CreateMap<Deneme, UpdatedDenemeResponse>().ReverseMap();
        CreateMap<Deneme, DeleteDenemeCommand>().ReverseMap();
        CreateMap<Deneme, DeletedDenemeResponse>().ReverseMap();
        CreateMap<Deneme, GetByIdDenemeResponse>().ReverseMap();
        CreateMap<Deneme, GetListDenemeListItemDto>().ReverseMap();
        CreateMap<IPaginate<Deneme>, GetListResponse<GetListDenemeListItemDto>>().ReverseMap();
    }
}