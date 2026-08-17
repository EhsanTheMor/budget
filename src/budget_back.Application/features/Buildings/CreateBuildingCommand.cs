using budget_back.Application.Abstractions.Persist;
using budget_back.Domain.AggregatedModels;
using MediatR;

namespace budget_back.Application.Features.Buildings;

public record CreateBuildingCommand(
    string Name,
    int ManagerId,
    string? Description = null,
    string? Address = null) : IRequest<int>;

public class CreateBuildingCommandHandler(IBudgetDbContext context) : IRequestHandler<CreateBuildingCommand, int>
{
    public async Task<int> Handle(CreateBuildingCommand request, CancellationToken cancellationToken)
    {
        var building = new Building(request.Name, request.ManagerId, request.Description, request.Address);
        await context.Buildings.AddAsync(building, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        return building.Id;
    }
}
