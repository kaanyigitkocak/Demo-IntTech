using NArchitecture.Core.Persistence.Repositories;

public class Source : Entity<Guid>
{
    public string Name { get; set; }

    public virtual ICollection<Event> Events { get; set; }

    public Source()
    {
        Events = new List<Event>();
    }

    public void DisplaySourceInfo()
    {
        Console.WriteLine($"Source ID: {Id}");
        Console.WriteLine($"Name: {Name}");
    }
}