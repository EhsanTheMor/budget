using budget_back.Application.Abstractions.Persist;
using budget_back.Application.Mappings;
using budget_back.Application.Response;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace budget_back.Application.Features.Families;

public record GetFamiliesQuery : IRequest<IReadOnlyList<FamilyResponse>>;

public class GetFamiliesQueryHandler(IBudgetDbContext context)
    : IRequestHandler<GetFamiliesQuery, IReadOnlyList<FamilyResponse>>
{
    public async Task<IReadOnlyList<FamilyResponse>> Handle(GetFamiliesQuery request, CancellationToken cancellationToken)
    {
        var families = await context.Families
            .AsNoTracking()
            .Include(family => family.Users)
            .OrderBy(family => family.Id)
            .ToListAsync(cancellationToken);

        return families.ToResponse();
    }
}
