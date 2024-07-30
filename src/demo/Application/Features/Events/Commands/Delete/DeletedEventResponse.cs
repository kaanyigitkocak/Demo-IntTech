using NArchitecture.Core.Application.Responses;

namespace Application.Features.Events.Commands.Delete;

public class DeletedEventResponse : IResponse
{
    public Guid Id { get; set; }
}