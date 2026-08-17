using budget_back.Application.Abstractions.Persist;
using budget_back.Application.Mappings;
using budget_back.Application.Response;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace budget_back.Application.Features.Travels;

public record AddUsersToTravelCommand(int Id, IReadOnlyList<int> UserIds)
    : IRequest<AddUsersToTravelResult>;

public record AddUsersToTravelResult(
    bool EntityFound,
    bool AllUsersFound,
    TravelResponse? Travel);

public class AddUsersToTravelCommandHandler(IBudgetDbContext context)
    : IRequestHandler<AddUsersToTravelCommand, AddUsersToTravelResult>
{
    public async Task<AddUsersToTravelResult> Handle(
        AddUsersToTravelCommand request,
        CancellationToken cancellationToken)
    {
        var travel = await context.Travels
            .Include(item => item.Users)
            .FirstOrDefaultAsync(item => item.Id == request.Id, cancellationToken);

        if (travel is null)
        {
            return new AddUsersToTravelResult(false, false, null);
        }

        var userIds = (request.UserIds ?? []).Distinct().ToList();
        var users = await context.Users
            .Where(user => userIds.Contains(user.Id))
            .ToListAsync(cancellationToken);

        if (users.Count != userIds.Count)
        {
            return new AddUsersToTravelResult(true, false, null);
        }

        travel.AddUsers(users);
        await context.SaveChangesAsync(cancellationToken);
        return new AddUsersToTravelResult(true, true, travel.ToResponse());
    }
}
