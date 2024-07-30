using NArchitecture.Core.Application.Responses;

namespace Application.Features.Sources.Commands.Delete;

public class DeletedSourceResponse : IResponse
{
    public Guid Id { get; set; }
}