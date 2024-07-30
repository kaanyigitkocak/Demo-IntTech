using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Denemes.Queries.GetList;

public class GetListDenemeListItemDto : IDto
{
    public Guid Id { get; set; }
    public string? ActivationKey { get; set; }
    public bool IsVerified { get; set; }
}