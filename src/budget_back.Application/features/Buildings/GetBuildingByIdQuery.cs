using budget_back.Application.Abstractions.Persist;
using budget_back.Application.Mappings;
using budget_back.Application.Response;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace budget_back.Application.Features.Buildings;

public record GetBuildingByIdQuery(int Id) : IRequest<BuildingResponse?>;

public class GetBuildingByIdQueryHandler(IBudgetDbContext context)
    : IRequestHandler<GetBuildingByIdQuery, BuildingResponse?>
{
    public async Task<BuildingResponse?> Handle(GetBuildingByIdQuery request, CancellationToken cancellationToken)
    {
        var building = await context.Buildings
            .AsNoTracking()
            .Include(item => item.Users)
            .FirstOrDefaultAsync(item => item.Id == request.Id, cancellationToken);

        return building?.ToResponse();
    }
}
