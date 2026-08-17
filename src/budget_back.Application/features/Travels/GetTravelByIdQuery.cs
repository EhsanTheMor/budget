using budget_back.Application.Abstractions.Persist;
using budget_back.Application.Mappings;
using budget_back.Application.Response;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace budget_back.Application.Features.Travels;

public record GetTravelByIdQuery(int Id) : IRequest<TravelResponse?>;

public class GetTravelByIdQueryHandler(IBudgetDbContext context)
    : IRequestHandler<GetTravelByIdQuery, TravelResponse?>
{
    public async Task<TravelResponse?> Handle(GetTravelByIdQuery request, CancellationToken cancellationToken)
    {
        var travel = await context.Travels
            .AsNoTracking()
            .Include(item => item.Users)
            .FirstOrDefaultAsync(item => item.Id == request.Id, cancellationToken);

        return travel?.ToResponse();
    }
}
