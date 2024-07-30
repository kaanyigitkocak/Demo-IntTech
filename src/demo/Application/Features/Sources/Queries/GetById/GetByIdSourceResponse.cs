using NArchitecture.Core.Application.Responses;

namespace Application.Features.Sources.Queries.GetById;

public class GetByIdSourceResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}