using budget_back.Application.Abstractions.Persist;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace budget_back.Application.Features.Buildings;

public record DeleteBuildingCommand(int Id) : IRequest<bool>;

public class DeleteBuildingCommandHandler(IBudgetDbContext context) : IRequestHandler<DeleteBuildingCommand, bool>
{
    public async Task<bool> Handle(DeleteBuildingCommand request, CancellationToken cancellationToken)
    {
        var building = await context.Buildings
            .Include(item => item.ExpenseScope)
            .FirstOrDefaultAsync(item => item.Id == request.Id, cancellationToken);

        if (building is null)
        {
            return false;
        }

        context.Buildings.Remove(building);
        context.ExpenseScopes.Remove(building.ExpenseScope);
        await context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
