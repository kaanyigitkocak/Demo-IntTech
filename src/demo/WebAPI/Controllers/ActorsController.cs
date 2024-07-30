using Application.Features.Actors.Commands.Create;
using Application.Features.Actors.Commands.Delete;
using Application.Features.Actors.Commands.Update;
using Application.Features.Actors.Queries.GetById;
using Application.Features.Actors.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ActorsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateActorCommand createActorCommand)
    {
        CreatedActorResponse response = await Mediator.Send(createActorCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateActorCommand updateActorCommand)
    {
        UpdatedActorResponse response = await Mediator.Send(updateActorCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedActorResponse response = await Mediator.Send(new DeleteActorCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdActorResponse response = await Mediator.Send(new GetByIdActorQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListActorQuery getListActorQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListActorListItemDto> response = await Mediator.Send(getListActorQuery);
        return Ok(response);
    }
}