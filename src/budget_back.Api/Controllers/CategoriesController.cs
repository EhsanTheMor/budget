using budget_back.Application.Features.Categories;
using budget_back.Application.Mappings;
using budget_back.Application.Request;
using budget_back.Application.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace budget_back.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
[Tags("Categories")]
public class CategoriesController(IMediator mediator) : ControllerBase
{
    [HttpGet(Name = nameof(GetCategories))]
    [ProducesResponseType(typeof(IReadOnlyList<CategoryResponse>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<CategoryResponse>>> GetCategories(CancellationToken cancellationToken)
    {
        var query = new GetCategoriesQuery();
        var categories = await mediator.Send(query, cancellationToken);
        return Ok(categories);
    }

    [HttpGet("{id:int}", Name = nameof(GetCategoryById))]
    [ProducesResponseType(typeof(CategoryResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CategoryResponse>> GetCategoryById(int id, CancellationToken cancellationToken)
    {
        var query = new GetCategoryByIdQuery(id);
        var category = await mediator.Send(query, cancellationToken);
        return category is null ? NotFound() : Ok(category);
    }

    [HttpPost(Name = nameof(CreateCategory))]
    [ProducesResponseType(typeof(CategoryResponse), StatusCodes.Status201Created)]
    public async Task<ActionResult<CategoryResponse>> CreateCategory(
        CreateCategoryRequest request,
        CancellationToken cancellationToken)
    {
        var command = request.ToCommand();
        var category = await mediator.Send(command, cancellationToken);
        return CreatedAtAction(nameof(GetCategoryById), new { id = category.Id }, category);
    }

    [HttpPut("{id:int}", Name = nameof(UpdateCategory))]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateCategory(
        int id,
        UpdateCategoryRequest request,
        CancellationToken cancellationToken)
    {
        var command = request.ToCommand(id);
        var updated = await mediator.Send(command, cancellationToken);
        return updated ? NoContent() : NotFound();
    }

    [HttpPost("{id:int}/expences", Name = nameof(AddExpenceToCategory))]
    [ProducesResponseType(typeof(ExpenceResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ExpenceResponse>> AddExpenceToCategory(
        int id,
        AddExpenceRequest request,
        CancellationToken cancellationToken)
    {
        var command = request.ToAddExpenceToCategoryCommand(id);
        var result = await mediator.Send(command, cancellationToken);

        if (!result.EntityFound)
        {
            return NotFound();
        }

        if (!result.BankAccountFound)
        {
            return BadRequest("Bank account was not found.");
        }

        return Created($"/api/Categories/{id}/expences/{result.Expence!.Id}", result.Expence);
    }

    [HttpDelete("{id:int}", Name = nameof(DeleteCategory))]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteCategory(int id, CancellationToken cancellationToken)
    {
        var command = new DeleteCategoryCommand(id);
        var deleted = await mediator.Send(command, cancellationToken);
        return deleted ? NoContent() : NotFound();
    }
}
