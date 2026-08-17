using budget_back.Application.Abstractions.Persist;
using budget_back.Application.Mappings;
using budget_back.Application.Response;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace budget_back.Application.Features.Families;

public record AddUsersToFamilyCommand(int Id, IReadOnlyList<int> UserIds)
    : IRequest<AddUsersToFamilyResult>;

public record AddUsersToFamilyResult(
    bool EntityFound,
    bool AllUsersFound,
    FamilyResponse? Family);

public class AddUsersToFamilyCommandHandler(IBudgetDbContext context)
    : IRequestHandler<AddUsersToFamilyCommand, AddUsersToFamilyResult>
{
    public async Task<AddUsersToFamilyResult> Handle(
        AddUsersToFamilyCommand request,
        CancellationToken cancellationToken)
    {
        var family = await context.Families
            .Include(item => item.Users)
            .FirstOrDefaultAsync(item => item.Id == request.Id, cancellationToken);

        if (family is null)
        {
            return new AddUsersToFamilyResult(false, false, null);
        }

        var userIds = (request.UserIds ?? []).Distinct().ToList();
        var users = await context.Users
            .Where(user => userIds.Contains(user.Id))
            .ToListAsync(cancellationToken);

        if (users.Count != userIds.Count)
        {
            return new AddUsersToFamilyResult(true, false, null);
        }

        family.AddUsers(users);
        await context.SaveChangesAsync(cancellationToken);
        return new AddUsersToFamilyResult(true, true, family.ToResponse());
    }
}
