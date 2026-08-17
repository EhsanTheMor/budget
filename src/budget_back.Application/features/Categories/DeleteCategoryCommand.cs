using budget_back.Application.Abstractions.Persist;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace budget_back.Application.Features.Categories;

public record DeleteCategoryCommand(int Id) : IRequest<bool>;

public class DeleteCategoryCommandHandler(IBudgetDbContext context) : IRequestHandler<DeleteCategoryCommand, bool>
{
    public async Task<bool> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await context.Categories
            .Include(item => item.ExpenseScope)
            .FirstOrDefaultAsync(item => item.Id == request.Id, cancellationToken);

        if (category is null)
        {
            return false;
        }

        context.Categories.Remove(category);
        context.ExpenseScopes.Remove(category.ExpenseScope);
        await context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
