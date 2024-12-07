using MediatR;

using Microsoft.AspNetCore.Mvc;

using Shared;
using Shared.ValueObjects;
using Shared.ValueObjects.Location;
using Shared.ValueObjects.Name;

using ToDoList.Application.Domain.Activities;

namespace ToDoList.Application.Features;

public class CreateEventController : ApiControllerBase
{
    [HttpPost("/events")]
    public async Task<ActionResult<CreateEventCommandResponse>> Create([FromBody] CreateEventCommand command)
    {
        return await Mediator.Send(command);
    }
}

public record CreateEventCommand(Name Name, DateTimeOffset BeginDate, DateTimeOffset EndDate, Location Location,
    byte[]? Photo, List<string>[]? Links) : IRequest<CreateEventCommandResponse>;

public record CreateEventCommandResponse(Guid Id);

internal sealed class CreateEventCommandHandler() : IRequestHandler<CreateEventCommand, CreateEventCommandResponse>
{
    public async Task<CreateEventCommandResponse> Handle(CreateEventCommand request, CancellationToken cancellationToken)
    {
        var entity = Event.CreateEvent(request.Name, request.BeginDate, request.EndDate, request.Location,
            request.Photo, request.Links);

        entity.DomainEvents.Add(new EventCreatedEvent());

        return new CreateEventCommandResponse(entity.Id.Value);
    }
}