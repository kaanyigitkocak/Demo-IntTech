using NArchitecture.Core.Application.Responses;

namespace Application.Features.Denemes.Commands.Update;

public class UpdatedDenemeResponse : IResponse
{
    public Guid Id { get; set; }
    public string? ActivationKey { get; set; }
    public bool IsVerified { get; set; }
}