using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Sources.Queries.GetList;

public class GetListSourceListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}