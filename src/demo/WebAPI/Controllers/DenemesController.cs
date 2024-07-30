using Application.Features.Denemes.Commands.Create;
using Application.Features.Denemes.Commands.Delete;
using Application.Features.Denemes.Commands.Update;
using Application.Features.Denemes.Queries.GetById;
using Application.Features.Denemes.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DenemesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateDenemeCommand createDenemeCommand)
    {
        CreatedDenemeResponse response = await Mediator.Send(createDenemeCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateDenemeCommand updateDenemeCommand)
    {
        UpdatedDenemeResponse response = await Mediator.Send(updateDenemeCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedDenemeResponse response = await Mediator.Send(new DeleteDenemeCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdDenemeResponse response = await Mediator.Send(new GetByIdDenemeQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListDenemeQuery getListDenemeQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListDenemeListItemDto> response = await Mediator.Send(getListDenemeQuery);
        return Ok(response);
    }
}