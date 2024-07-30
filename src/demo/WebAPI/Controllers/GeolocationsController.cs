using Application.Features.Geolocations.Commands.Create;
using Application.Features.Geolocations.Commands.Delete;
using Application.Features.Geolocations.Commands.Update;
using Application.Features.Geolocations.Queries.GetById;
using Application.Features.Geolocations.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GeolocationsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateGeolocationCommand createGeolocationCommand)
    {
        CreatedGeolocationResponse response = await Mediator.Send(createGeolocationCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateGeolocationCommand updateGeolocationCommand)
    {
        UpdatedGeolocationResponse response = await Mediator.Send(updateGeolocationCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedGeolocationResponse response = await Mediator.Send(new DeleteGeolocationCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdGeolocationResponse response = await Mediator.Send(new GetByIdGeolocationQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListGeolocationQuery getListGeolocationQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListGeolocationListItemDto> response = await Mediator.Send(getListGeolocationQuery);
        return Ok(response);
    }
}