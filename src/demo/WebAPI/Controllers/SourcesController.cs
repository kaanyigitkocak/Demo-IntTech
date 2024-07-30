using Application.Features.Sources.Commands.Create;
using Application.Features.Sources.Commands.Delete;
using Application.Features.Sources.Commands.Update;
using Application.Features.Sources.Queries.GetById;
using Application.Features.Sources.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SourcesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateSourceCommand createSourceCommand)
    {
        CreatedSourceResponse response = await Mediator.Send(createSourceCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateSourceCommand updateSourceCommand)
    {
        UpdatedSourceResponse response = await Mediator.Send(updateSourceCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedSourceResponse response = await Mediator.Send(new DeleteSourceCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdSourceResponse response = await Mediator.Send(new GetByIdSourceQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListSourceQuery getListSourceQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListSourceListItemDto> response = await Mediator.Send(getListSourceQuery);
        return Ok(response);
    }
}