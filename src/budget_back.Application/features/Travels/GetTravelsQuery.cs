using budget_back.Application.Abstractions.Persist;
using budget_back.Application.Mappings;
using budget_back.Application.Response;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace budget_back.Application.Features.Travels;

public record GetTravelsQuery : IRequest<IReadOnlyList<TravelResponse>>;

public class GetTravelsQueryHandler(IBudgetDbContext context)
    : IRequestHandler<GetTravelsQuery, IReadOnlyList<TravelResponse>>
{
    public async Task<IReadOnlyList<TravelResponse>> Handle(GetTravelsQuery request, CancellationToken cancellationToken)
    {
        var travels = await context.Travels
            .AsNoTracking()
            .Include(travel => travel.Users)
            .OrderBy(travel => travel.Id)
            .ToListAsync(cancellationToken);

        return travels.ToResponse();
    }
}
