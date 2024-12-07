namespace ToDoList.Application.Domain.Activities;

public readonly record struct EventId(Guid Value)
{
    public EventId() : this(Guid.NewGuid())
    {
    }

    public override string ToString() => Value.ToString();
}