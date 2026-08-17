using budget_back.Application.Abstractions.Persist;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace budget_back.Application.Features.Travels;

public record UpdateTravelCommand(
    int Id,
    int ManagerId,
    string Name,
    string? Description = null,
    DateTime? StartDate = null,
    DateTime? EndDate = null) : IRequest<bool>;

public class UpdateTravelCommandHandler(IBudgetDbContext context) : IRequestHandler<UpdateTravelCommand, bool>
{
    public async Task<bool> Handle(UpdateTravelCommand request, CancellationToken cancellationToken)
    {
        var travel = await context.Travels
            .FirstOrDefaultAsync(item => item.Id == request.Id, cancellationToken);

        if (travel is null)
        {
            return false;
        }

        travel.Update(request.ManagerId, request.Name, request.Description, request.StartDate, request.EndDate);
        await context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
