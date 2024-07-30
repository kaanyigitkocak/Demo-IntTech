using NArchitecture.Core.Persistence.Repositories;
using System.Collections.Generic;

public class Actor : Entity<Guid>
{
    public string Name { get; set; }

    public virtual ICollection<Event> EventsAsActor1 { get; set; }
    public virtual ICollection<Event> EventsAsActor2 { get; set; }

    public Actor()
    {
        EventsAsActor1 = new List<Event>();
        EventsAsActor2 = new List<Event>();
    }

    public void DisplayActorInfo()
    {
        Console.WriteLine($"Actor ID: {Id}");
        Console.WriteLine($"Name: {Name}");
    }
}