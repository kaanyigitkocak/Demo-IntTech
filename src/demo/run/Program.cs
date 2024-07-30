using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using Domain.Entities;

class Program
{
    static void Main(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<BaseDbContext>();
        optionsBuilder.UseSqlServer("Server=localhost;Database=EventDb;User Id=SA;Password=Password123;MultipleActiveResultSets=true;Encrypt=false");

        using (var context = new BaseDbContext(optionsBuilder.Options))
        {
            var actors = new Dictionary<string, Actor>();
            var geolocations = new Dictionary<string, Geolocation>();
            var sources = new Dictionary<string, Source>();
            var events = new List<Event>();

            using (var reader = new StreamReader("mockup.csv"))
            {
                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    MissingFieldFound = null,
                };

                using (var csv = new CsvReader(reader, config))
                {
                    csv.Read();
                    csv.ReadHeader();
                    while (csv.Read())
                    {
                        var actor1Name = csv.GetField<string>("actor1");
                        var actor2Name = csv.GetField<string>("actor2");
                        var country = csv.GetField<string>("country");
                        var admin1 = csv.GetField<string>("admin1");
                        var admin2 = csv.GetField<string>("admin2");
                        var sourceName = csv.GetField<string>("source");
                        var description = csv.GetField<string>("notes");
                        var fatalities = csv.GetField<int>("fatalities");
                        var eventTypeString = csv.GetField<string>("event_type");
                        var date = DateTime.Parse(csv.GetField<string>("event_date"));

                        var eventType = NormalizeEventType(eventTypeString);

                        if (!actors.ContainsKey(actor1Name))
                        {
                            var actor = new Actor { Name = actor1Name };
                            actors[actor1Name] = actor;
                            context.Actors.Add(actor);
                        }

                        if (!actors.ContainsKey(actor2Name))
                        {
                            var actor = new Actor { Name = actor2Name };
                            actors[actor2Name] = actor;
                            context.Actors.Add(actor);
                        }

                        if (!geolocations.ContainsKey($"{country}-{admin1}-{admin2}"))
                        {
                            var geolocation = new Geolocation
                            {
                                Country = country,
                                Admin1 = admin1,
                                Admin2 = admin2,
                                Latitude = csv.GetField<double>("latitude"),
                                Longitude = csv.GetField<double>("longitude")
                            };
                            geolocations[$"{country}-{admin1}-{admin2}"] = geolocation;
                            context.Geolocations.Add(geolocation);
                        }

                        if (!sources.ContainsKey(sourceName))
                        {
                            var source = new Source { Name = sourceName };
                            sources[sourceName] = source;
                            context.Sources.Add(source);
                        }

                        var evt = new Event
                        {
                            Actor1 = actors[actor1Name],
                            Actor2 = actors[actor2Name],
                            Geolocation = geolocations[$"{country}-{admin1}-{admin2}"],
                            Source = sources[sourceName],
                            Description = description,
                            Fatalities = fatalities,
                            EventType = eventType,
                            Date = date
                        };

                        events.Add(evt);
                        context.Events.Add(evt);
                    }
                }
            }

            context.SaveChanges();
        }

        Console.WriteLine("Data import complete.");
    }

    static EventType NormalizeEventType(string eventTypeString)
    {
        return eventTypeString.ToLower() switch
        {
            "battles" => EventType.Battles,
            "strategic developments" => EventType.Strategic_Developments,
            "protests" => EventType.Protests,
            "explosions/remote violence" => EventType.Explosions_Remote_Violence,
            "riots" => EventType.Riots,
            "violence against civilians" => EventType.Violence_Against_Civilians,
            _ => EventType.Unknown,
        };
    }
}