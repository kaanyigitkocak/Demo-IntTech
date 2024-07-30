using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Actors.Queries.GetList;

public class GetListActorListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}