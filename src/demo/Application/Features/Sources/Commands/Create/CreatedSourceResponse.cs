using NArchitecture.Core.Application.Responses;

namespace Application.Features.Sources.Commands.Create;

public class CreatedSourceResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}