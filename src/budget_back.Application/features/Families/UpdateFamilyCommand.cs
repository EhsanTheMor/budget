using budget_back.Application.Abstractions.Persist;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace budget_back.Application.Features.Families;

public record UpdateFamilyCommand(
    int Id,
    string Name,
    int ManagerId,
    string? Description = null) : IRequest<bool>;

public class UpdateFamilyCommandHandler(IBudgetDbContext context) : IRequestHandler<UpdateFamilyCommand, bool>
{
    public async Task<bool> Handle(UpdateFamilyCommand request, CancellationToken cancellationToken)
    {
        var family = await context.Families
            .FirstOrDefaultAsync(item => item.Id == request.Id, cancellationToken);

        if (family is null)
        {
            return false;
        }

        family.Update(request.Name, request.ManagerId, request.Description);
        await context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
