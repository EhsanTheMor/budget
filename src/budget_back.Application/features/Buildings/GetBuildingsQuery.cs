using budget_back.Application.Abstractions.Persist;
using budget_back.Application.Mappings;
using budget_back.Application.Response;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace budget_back.Application.Features.Buildings;

public record GetBuildingsQuery : IRequest<IReadOnlyList<BuildingResponse>>;

public class GetBuildingsQueryHandler(IBudgetDbContext context)
    : IRequestHandler<GetBuildingsQuery, IReadOnlyList<BuildingResponse>>
{
    public async Task<IReadOnlyList<BuildingResponse>> Handle(GetBuildingsQuery request, CancellationToken cancellationToken)
    {
        var buildings = await context.Buildings
            .AsNoTracking()
            .Include(building => building.Users)
            .OrderBy(building => building.Id)
            .ToListAsync(cancellationToken);

        return buildings.ToResponse();
    }
}
