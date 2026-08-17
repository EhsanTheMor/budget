using budget_back.Application.Abstractions.Persist;
using budget_back.Application.Mappings;
using budget_back.Application.Response;
using budget_back.Domain.AggregatedModels;
using MediatR;

namespace budget_back.Application.Features.Travels;

public record CreateTravelCommand(
    int ManagerId,
    string Name,
    string? Description = null,
    DateTime? StartDate = null,
    DateTime? EndDate = null) : IRequest<TravelResponse>;

public class CreateTravelCommandHandler(IBudgetDbContext context)
    : IRequestHandler<CreateTravelCommand, TravelResponse>
{
    public async Task<TravelResponse> Handle(CreateTravelCommand request, CancellationToken cancellationToken)
    {
        var travel = new Travel(request.ManagerId, request.Name, request.Description, request.StartDate, request.EndDate);
        await context.Travels.AddAsync(travel, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        return travel.ToResponse();
    }
}
