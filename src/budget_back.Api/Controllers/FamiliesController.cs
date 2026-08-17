using budget_back.Application.Features.Families;
using budget_back.Application.Mappings;
using budget_back.Application.Request;
using budget_back.Application.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace budget_back.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
[Tags("Families")]
public class FamiliesController(IMediator mediator) : ControllerBase
{
    [HttpGet(Name = nameof(GetFamilies))]
    [ProducesResponseType(typeof(IReadOnlyList<FamilyResponse>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<FamilyResponse>>> GetFamilies(CancellationToken cancellationToken)
    {
        var query = new GetFamiliesQuery();
        var families = await mediator.Send(query, cancellationToken);
        return Ok(families);
    }

    [HttpGet("{id:int}", Name = nameof(GetFamilyById))]
    [ProducesResponseType(typeof(FamilyResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<FamilyResponse>> GetFamilyById(int id, CancellationToken cancellationToken)
    {
        var query = new GetFamilyByIdQuery(id);
        var family = await mediator.Send(query, cancellationToken);
        return family is null ? NotFound() : Ok(family);
    }

    [HttpPost(Name = nameof(CreateFamily))]
    [ProducesResponseType(typeof(FamilyResponse), StatusCodes.Status201Created)]
    public async Task<ActionResult<FamilyResponse>> CreateFamily(
        CreateFamilyRequest request,
        CancellationToken cancellationToken)
    {
        var command = request.ToCommand();
        var family = await mediator.Send(command, cancellationToken);
        return CreatedAtAction(nameof(GetFamilyById), new { id = family.Id }, family);
    }

    [HttpPut("{id:int}", Name = nameof(UpdateFamily))]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateFamily(
        int id,
        UpdateFamilyRequest request,
        CancellationToken cancellationToken)
    {
        var command = request.ToCommand(id);
        var updated = await mediator.Send(command, cancellationToken);
        return updated ? NoContent() : NotFound();
    }

    [HttpPost("{id:int}/users", Name = nameof(AddUsersToFamily))]
    [ProducesResponseType(typeof(FamilyResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<FamilyResponse>> AddUsersToFamily(
        int id,
        AddUsersRequest request,
        CancellationToken cancellationToken)
    {
        var command = request.ToAddUsersToFamilyCommand(id);
        var result = await mediator.Send(command, cancellationToken);

        if (!result.EntityFound)
        {
            return NotFound();
        }

        if (!result.AllUsersFound)
        {
            return BadRequest("One or more users were not found.");
        }

        return Ok(result.Family);
    }

    [HttpPost("{id:int}/expences", Name = nameof(AddExpenceToFamily))]
    [ProducesResponseType(typeof(ExpenceResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ExpenceResponse>> AddExpenceToFamily(
        int id,
        AddExpenceRequest request,
        CancellationToken cancellationToken)
    {
        var command = request.ToAddExpenceToFamilyCommand(id);
        var result = await mediator.Send(command, cancellationToken);

        if (!result.EntityFound)
        {
            return NotFound();
        }

        if (!result.BankAccountFound)
        {
            return BadRequest("Bank account was not found.");
        }

        return Created($"/api/Families/{id}/expences/{result.Expence!.Id}", result.Expence);
    }

    [HttpDelete("{id:int}", Name = nameof(DeleteFamily))]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteFamily(int id, CancellationToken cancellationToken)
    {
        var command = new DeleteFamilyCommand(id);
        var deleted = await mediator.Send(command, cancellationToken);
        return deleted ? NoContent() : NotFound();
    }
}
