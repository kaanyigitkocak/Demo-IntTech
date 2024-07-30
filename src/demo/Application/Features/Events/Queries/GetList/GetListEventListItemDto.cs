using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Events.Queries.GetList;

public class GetListEventListItemDto : IDto
{
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public EventType EventType { get; set; }
    public string EventTypeName => EventType.ToString();
    public Guid Actor1Id { get; set; }
    public Guid? Actor2Id { get; set; }
    public Guid GeolocationId { get; set; }
    public Guid SourceId { get; set; }
    public string Description { get; set; }
    public int Fatalities { get; set; }
}