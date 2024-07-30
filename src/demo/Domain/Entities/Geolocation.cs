using NArchitecture.Core.Persistence.Repositories;

public class Geolocation : Entity<Guid>
{
    public string Country { get; set; }
    public string Admin1 { get; set; }
    public string Admin2 { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }

    public virtual ICollection<Event> Events { get; set; }

    public Geolocation()
    {
        Events = new List<Event>();
    }

    public void DisplayLocationInfo()
    {
        Console.WriteLine($"Geolocation ID: {Id}");
        Console.WriteLine($"Country: {Country}");
        Console.WriteLine($"Admin1: {Admin1}");
        Console.WriteLine($"Admin2: {Admin2}");
        Console.WriteLine($"Latitude: {Latitude}");
        Console.WriteLine($"Longitude: {Longitude}");
    }
}