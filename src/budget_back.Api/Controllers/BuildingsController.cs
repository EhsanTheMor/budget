using budget_back.Application.Features.Buildings;
using budget_back.Application.Mappings;
using budget_back.Application.Request;
using budget_back.Application.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace budget_back.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
[Tags("Buildings")]
public class BuildingsController(IMediator mediator) : ControllerBase
{
    [HttpGet(Name = nameof(GetBuildings))]
    [ProducesResponseType(typeof(IReadOnlyList<BuildingResponse>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<BuildingResponse>>> GetBuildings(CancellationToken cancellationToken)
    {
        var query = new GetBuildingsQuery();
        var buildings = await mediator.Send(query, cancellationToken);
        return Ok(buildings);
    }

    [HttpGet("{id:int}", Name = nameof(GetBuildingById))]
    [ProducesResponseType(typeof(BuildingResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<BuildingResponse>> GetBuildingById(int id, CancellationToken cancellationToken)
    {
        var query = new GetBuildingByIdQuery(id);
        var building = await mediator.Send(query, cancellationToken);
        return building is null ? NotFound() : Ok(building);
    }

    [HttpPost(Name = nameof(CreateBuilding))]
    [ProducesResponseType(typeof(BuildingResponse), StatusCodes.Status201Created)]
    public async Task<ActionResult<BuildingResponse>> CreateBuilding(
        CreateBuildingRequest request,
        CancellationToken cancellationToken)
    {
        var command = request.ToCommand();
        var building = await mediator.Send(command, cancellationToken);
        return CreatedAtAction(nameof(GetBuildingById), new { id = building.Id }, building);
    }

    [HttpPut("{id:int}", Name = nameof(UpdateBuilding))]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateBuilding(
        int id,
        UpdateBuildingRequest request,
        CancellationToken cancellationToken)
    {
        var command = request.ToCommand(id);
        var updated = await mediator.Send(command, cancellationToken);
        return updated ? NoContent() : NotFound();
    }

    [HttpPost("{id:int}/users", Name = nameof(AddUsersToBuilding))]
    [ProducesResponseType(typeof(BuildingResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<BuildingResponse>> AddUsersToBuilding(
        int id,
        AddUsersRequest request,
        CancellationToken cancellationToken)
    {
        var command = request.ToAddUsersToBuildingCommand(id);
        var result = await mediator.Send(command, cancellationToken);

        if (!result.EntityFound)
        {
            return NotFound();
        }

        if (!result.AllUsersFound)
        {
            return BadRequest("One or more users were not found.");
        }

        return Ok(result.Building);
    }

    [HttpPost("{id:int}/expences", Name = nameof(AddExpenceToBuilding))]
    [ProducesResponseType(typeof(ExpenceResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ExpenceResponse>> AddExpenceToBuilding(
        int id,
        AddExpenceRequest request,
        CancellationToken cancellationToken)
    {
        var command = request.ToAddExpenceToBuildingCommand(id);
        var result = await mediator.Send(command, cancellationToken);

        if (!result.EntityFound)
        {
            return NotFound();
        }

        if (!result.BankAccountFound)
        {
            return BadRequest("Bank account was not found.");
        }

        return Created($"/api/Buildings/{id}/expences/{result.Expence!.Id}", result.Expence);
    }

    [HttpDelete("{id:int}", Name = nameof(DeleteBuilding))]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteBuilding(int id, CancellationToken cancellationToken)
    {
        var command = new DeleteBuildingCommand(id);
        var deleted = await mediator.Send(command, cancellationToken);
        return deleted ? NoContent() : NotFound();
    }
}
