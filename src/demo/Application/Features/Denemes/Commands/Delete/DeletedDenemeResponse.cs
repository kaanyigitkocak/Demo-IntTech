using NArchitecture.Core.Application.Responses;

namespace Application.Features.Denemes.Commands.Delete;

public class DeletedDenemeResponse : IResponse
{
    public Guid Id { get; set; }
}