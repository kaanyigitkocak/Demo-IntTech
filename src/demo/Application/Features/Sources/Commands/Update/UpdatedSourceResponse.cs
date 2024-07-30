using NArchitecture.Core.Application.Responses;

namespace Application.Features.Sources.Commands.Update;

public class UpdatedSourceResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}