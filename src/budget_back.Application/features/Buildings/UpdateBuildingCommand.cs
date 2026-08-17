using budget_back.Application.Abstractions.Persist;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace budget_back.Application.Features.Buildings;

public record UpdateBuildingCommand(
    int Id,
    string Name,
    int ManagerId,
    string? Description = null,
    string? Address = null) : IRequest<bool>;

public class UpdateBuildingCommandHandler(IBudgetDbContext context) : IRequestHandler<UpdateBuildingCommand, bool>
{
    public async Task<bool> Handle(UpdateBuildingCommand request, CancellationToken cancellationToken)
    {
        var building = await context.Buildings
            .FirstOrDefaultAsync(item => item.Id == request.Id, cancellationToken);

        if (building is null)
        {
            return false;
        }

        building.Update(request.Name, request.ManagerId, request.Description, request.Address);
        await context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
