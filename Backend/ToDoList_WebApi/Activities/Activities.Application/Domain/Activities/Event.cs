using Shared;
using Shared.ValueObjects;
using Shared.ValueObjects.Location;
using Shared.ValueObjects.Name;

namespace ToDoList.Application.Domain.Activities;

public class Event : IHasDomainEvent
{
    public static Event CreateEvent(Name name, DateTimeOffset beginDate, DateTimeOffset endDate, Location location,
        byte[]? photo, List<string>[]? links)
    {
        return new Event()
        {
            Links = links,
            Location = location,
            Photo = photo,
            Name = name,
            BeginDate = beginDate,
            Id = new EventId(),
            EndDate = endDate
        };
    }
    internal EventId Id { get; set; }

    internal Name Name { get; set; }

    internal DateTimeOffset BeginDate { get; set; }
    
    internal DateTimeOffset EndDate { get; set; }
    
    internal Location Location { get; set; }
    
    internal byte[]? Photo { get; set; }
    internal List<string>[]? Links { get; set; }

    public List<DomainEvent> DomainEvents { get; }
}