using NArchitecture.Core.Persistence.Repositories;
using System;

public class Event : Entity<Guid>
{
    public DateTime Date { get; set; }
    public EventType EventType { get; set; }

    public Guid Actor1Id { get; set; }
    public virtual Actor Actor1 { get; set; }

    public Guid? Actor2Id { get; set; }
    public virtual Actor? Actor2 { get; set; }

    public Guid GeolocationId { get; set; }
    public virtual Geolocation Geolocation { get; set; }

    public Guid SourceId { get; set; }
    public virtual Source Source { get; set; }

    public string Description { get; set; }
    public int Fatalities { get; set; }

    public Event()
    {
        // Default constructor
    }

    public void DisplayEventInfo()
    {
        Console.WriteLine($"Event ID: {Id}");
        Console.WriteLine($"Date: {Date}");
        Console.WriteLine($"Event Type: {EventType}");
        Console.WriteLine($"Description: {Description}");
        Console.WriteLine($"Fatalities: {Fatalities}");

        Actor1.DisplayActorInfo();
        
        if (Actor2 != null)
        {
            Actor2.DisplayActorInfo();
        }

        Geolocation.DisplayLocationInfo();
        Source.DisplaySourceInfo();
    }
}