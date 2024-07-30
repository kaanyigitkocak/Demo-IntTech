using NArchitecture.Core.Application.Responses;

namespace Application.Features.Actors.Commands.Update;

public class UpdatedActorResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}