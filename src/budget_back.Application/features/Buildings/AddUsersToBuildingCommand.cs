using budget_back.Application.Abstractions.Persist;
using budget_back.Application.Mappings;
using budget_back.Application.Response;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace budget_back.Application.Features.Buildings;

public record AddUsersToBuildingCommand(int Id, IReadOnlyList<int> UserIds)
    : IRequest<AddUsersToBuildingResult>;

public record AddUsersToBuildingResult(
    bool EntityFound,
    bool AllUsersFound,
    BuildingResponse? Building);

public class AddUsersToBuildingCommandHandler(IBudgetDbContext context)
    : IRequestHandler<AddUsersToBuildingCommand, AddUsersToBuildingResult>
{
    public async Task<AddUsersToBuildingResult> Handle(
        AddUsersToBuildingCommand request,
        CancellationToken cancellationToken)
    {
        var building = await context.Buildings
            .Include(item => item.Users)
            .FirstOrDefaultAsync(item => item.Id == request.Id, cancellationToken);

        if (building is null)
        {
            return new AddUsersToBuildingResult(false, false, null);
        }

        var userIds = (request.UserIds ?? []).Distinct().ToList();
        var users = await context.Users
            .Where(user => userIds.Contains(user.Id))
            .ToListAsync(cancellationToken);

        if (users.Count != userIds.Count)
        {
            return new AddUsersToBuildingResult(true, false, null);
        }

        building.AddUsers(users);
        await context.SaveChangesAsync(cancellationToken);
        return new AddUsersToBuildingResult(true, true, building.ToResponse());
    }
}
