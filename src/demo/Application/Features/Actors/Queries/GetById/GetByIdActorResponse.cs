using NArchitecture.Core.Application.Responses;

namespace Application.Features.Actors.Queries.GetById;

public class GetByIdActorResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}