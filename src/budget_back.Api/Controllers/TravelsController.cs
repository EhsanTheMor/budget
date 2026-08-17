using budget_back.Application.Features.Travels;
using budget_back.Application.Mappings;
using budget_back.Application.Request;
using budget_back.Application.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace budget_back.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
[Tags("Travels")]
public class TravelsController(IMediator mediator) : ControllerBase
{
    [HttpGet(Name = nameof(GetTravels))]
    [ProducesResponseType(typeof(IReadOnlyList<TravelResponse>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<TravelResponse>>> GetTravels(CancellationToken cancellationToken)
    {
        var query = new GetTravelsQuery();
        var travels = await mediator.Send(query, cancellationToken);
        return Ok(travels);
    }

    [HttpGet("{id:int}", Name = nameof(GetTravelById))]
    [ProducesResponseType(typeof(TravelResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TravelResponse>> GetTravelById(int id, CancellationToken cancellationToken)
    {
        var query = new GetTravelByIdQuery(id);
        var travel = await mediator.Send(query, cancellationToken);
        return travel is null ? NotFound() : Ok(travel);
    }

    [HttpPost(Name = nameof(CreateTravel))]
    [ProducesResponseType(typeof(TravelResponse), StatusCodes.Status201Created)]
    public async Task<ActionResult<TravelResponse>> CreateTravel(
        CreateTravelRequest request,
        CancellationToken cancellationToken)
    {
        var command = request.ToCommand();
        var travel = await mediator.Send(command, cancellationToken);
        return CreatedAtAction(nameof(GetTravelById), new { id = travel.Id }, travel);
    }

    [HttpPut("{id:int}", Name = nameof(UpdateTravel))]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateTravel(
        int id,
        UpdateTravelRequest request,
        CancellationToken cancellationToken)
    {
        var command = request.ToCommand(id);
        var updated = await mediator.Send(command, cancellationToken);
        return updated ? NoContent() : NotFound();
    }

    [HttpPost("{id:int}/users", Name = nameof(AddUsersToTravel))]
    [ProducesResponseType(typeof(TravelResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TravelResponse>> AddUsersToTravel(
        int id,
        AddUsersRequest request,
        CancellationToken cancellationToken)
    {
        var command = request.ToAddUsersToTravelCommand(id);
        var result = await mediator.Send(command, cancellationToken);

        if (!result.EntityFound)
        {
            return NotFound();
        }

        if (!result.AllUsersFound)
        {
            return BadRequest("One or more users were not found.");
        }

        return Ok(result.Travel);
    }

    [HttpPost("{id:int}/expences", Name = nameof(AddExpenceToTravel))]
    [ProducesResponseType(typeof(ExpenceResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ExpenceResponse>> AddExpenceToTravel(
        int id,
        AddExpenceRequest request,
        CancellationToken cancellationToken)
    {
        var command = request.ToAddExpenceToTravelCommand(id);
        var result = await mediator.Send(command, cancellationToken);

        if (!result.EntityFound)
        {
            return NotFound();
        }

        if (!result.BankAccountFound)
        {
            return BadRequest("Bank account was not found.");
        }

        return Created($"/api/Travels/{id}/expences/{result.Expence!.Id}", result.Expence);
    }

    [HttpDelete("{id:int}", Name = nameof(DeleteTravel))]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteTravel(int id, CancellationToken cancellationToken)
    {
        var command = new DeleteTravelCommand(id);
        var deleted = await mediator.Send(command, cancellationToken);
        return deleted ? NoContent() : NotFound();
    }
}
