using NArchitecture.Core.Application.Responses;

namespace Application.Features.Actors.Commands.Delete;

public class DeletedActorResponse : IResponse
{
    public Guid Id { get; set; }
}