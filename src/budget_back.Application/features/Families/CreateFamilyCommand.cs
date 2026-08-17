using budget_back.Application.Abstractions.Persist;
using budget_back.Application.Mappings;
using budget_back.Application.Response;
using budget_back.Domain.AggregatedModels;
using MediatR;

namespace budget_back.Application.Features.Families;

public record CreateFamilyCommand(
    string Name,
    int ManagerId,
    string? Description = null) : IRequest<FamilyResponse>;

public class CreateFamilyCommandHandler(IBudgetDbContext context)
    : IRequestHandler<CreateFamilyCommand, FamilyResponse>
{
    public async Task<FamilyResponse> Handle(CreateFamilyCommand request, CancellationToken cancellationToken)
    {
        var family = new Family(request.Name, request.ManagerId, request.Description);
        await context.Families.AddAsync(family, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        return family.ToResponse();
    }
}
