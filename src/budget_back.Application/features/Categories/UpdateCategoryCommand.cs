using budget_back.Application.Abstractions.Persist;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace budget_back.Application.Features.Categories;

public record UpdateCategoryCommand(
    int Id,
    string Name,
    string Description,
    string Type,
    string Icon,
    string Color) : IRequest<bool>;

public class UpdateCategoryCommandHandler(IBudgetDbContext context) : IRequestHandler<UpdateCategoryCommand, bool>
{
    public async Task<bool> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await context.Categories
            .FirstOrDefaultAsync(item => item.Id == request.Id, cancellationToken);

        if (category is null)
        {
            return false;
        }

        category.Update(request.Name, request.Description, request.Type, request.Icon, request.Color);
        await context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
