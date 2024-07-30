using Application.Features.Events.Commands.Create;
using Application.Features.Events.Commands.Delete;
using Application.Features.Events.Commands.Update;
using Application.Features.Events.Queries.GetById;
using Application.Features.Events.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using NArchitecture.Core.Persistence.Dynamic;
using Application.Features.Events.Queries.GetListByDynamic;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EventsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateEventCommand createEventCommand)
    {
        CreatedEventResponse response = await Mediator.Send(createEventCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateEventCommand updateEventCommand)
    {
        UpdatedEventResponse response = await Mediator.Send(updateEventCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedEventResponse response = await Mediator.Send(new DeleteEventCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdEventResponse response = await Mediator.Send(new GetByIdEventQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListEventQuery getListEventQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListEventListItemDto> response = await Mediator.Send(getListEventQuery);
        return Ok(response);
    }

    
    [HttpPost("GetListByDynamic")]
    public async Task<IActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest, [FromBody] DynamicQuery? dynamicQuery = null)
    {
        GetListByDynamicEventQuery getListByDynamicEventQuery = new() { PageRequest = pageRequest, DynamicQuery = dynamicQuery };
        GetListResponse<GetListByDynamicEventListDto> response = await Mediator.Send(getListByDynamicEventQuery);
        return Ok(response);
    }
}