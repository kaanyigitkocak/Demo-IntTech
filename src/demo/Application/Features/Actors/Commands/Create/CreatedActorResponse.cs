using NArchitecture.Core.Application.Responses;

namespace Application.Features.Actors.Commands.Create;

public class CreatedActorResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}