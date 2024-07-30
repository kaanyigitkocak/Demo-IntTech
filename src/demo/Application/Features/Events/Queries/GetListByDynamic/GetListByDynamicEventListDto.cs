using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Events.Queries.GetListByDynamic
{
    public class GetListByDynamicEventListDto : IDto
    {

        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public EventType EventType { get; set; }
        public string EventTypeName => EventType.ToString();
        public ActorDto Actor1 { get; set; }
        public ActorDto Actor2 { get; set; }
        public GeolocationDto Geolocation { get; set; }
        public SourceDto Source { get; set; }
        public string Description { get; set; }
        public int Fatalities { get; set; }

    }

}