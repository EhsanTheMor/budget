using budget_back.Application.Abstractions.Persist;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace budget_back.Application.Features.Travels;

public record DeleteTravelCommand(int Id) : IRequest<bool>;

public class DeleteTravelCommandHandler(IBudgetDbContext context) : IRequestHandler<DeleteTravelCommand, bool>
{
    public async Task<bool> Handle(DeleteTravelCommand request, CancellationToken cancellationToken)
    {
        var travel = await context.Travels
            .Include(item => item.ExpenseScope)
            .FirstOrDefaultAsync(item => item.Id == request.Id, cancellationToken);

        if (travel is null)
        {
            return false;
        }

        context.Travels.Remove(travel);
        context.ExpenseScopes.Remove(travel.ExpenseScope);
        await context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
