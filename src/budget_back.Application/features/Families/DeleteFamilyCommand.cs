using budget_back.Application.Abstractions.Persist;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace budget_back.Application.Features.Families;

public record DeleteFamilyCommand(int Id) : IRequest<bool>;

public class DeleteFamilyCommandHandler(IBudgetDbContext context) : IRequestHandler<DeleteFamilyCommand, bool>
{
    public async Task<bool> Handle(DeleteFamilyCommand request, CancellationToken cancellationToken)
    {
        var family = await context.Families
            .Include(item => item.ExpenseScope)
            .FirstOrDefaultAsync(item => item.Id == request.Id, cancellationToken);

        if (family is null)
        {
            return false;
        }

        context.Families.Remove(family);
        context.ExpenseScopes.Remove(family.ExpenseScope);
        await context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
