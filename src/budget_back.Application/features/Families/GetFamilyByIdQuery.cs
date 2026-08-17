using budget_back.Application.Abstractions.Persist;
using budget_back.Application.Mappings;
using budget_back.Application.Response;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace budget_back.Application.Features.Families;

public record GetFamilyByIdQuery(int Id) : IRequest<FamilyResponse?>;

public class GetFamilyByIdQueryHandler(IBudgetDbContext context)
    : IRequestHandler<GetFamilyByIdQuery, FamilyResponse?>
{
    public async Task<FamilyResponse?> Handle(GetFamilyByIdQuery request, CancellationToken cancellationToken)
    {
        var family = await context.Families
            .AsNoTracking()
            .Include(item => item.Users)
            .FirstOrDefaultAsync(item => item.Id == request.Id, cancellationToken);

        return family?.ToResponse();
    }
}
