using NArchitecture.Core.Application.Responses;

namespace Application.Features.Denemes.Queries.GetById;

public class GetByIdDenemeResponse : IResponse
{
    public Guid Id { get; set; }
    public string? ActivationKey { get; set; }
    public bool IsVerified { get; set; }
}