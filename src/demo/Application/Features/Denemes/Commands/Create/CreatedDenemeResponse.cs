using NArchitecture.Core.Application.Responses;

namespace Application.Features.Denemes.Commands.Create;

public class CreatedDenemeResponse : IResponse
{
    public Guid Id { get; set; }
    public string? ActivationKey { get; set; }
    public bool IsVerified { get; set; }
}