using budget_back.Application.Abstractions.Persist;
using budget_back.Application.Mappings;
using budget_back.Application.Response;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace budget_back.Application.Features.Categories;

public record GetCategoriesQuery : IRequest<IReadOnlyList<CategoryResponse>>;

public class GetCategoriesQueryHandler(IBudgetDbContext context)
    : IRequestHandler<GetCategoriesQuery, IReadOnlyList<CategoryResponse>>
{
    public async Task<IReadOnlyList<CategoryResponse>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
    {
        var categories = await context.Categories
            .AsNoTracking()
            .OrderBy(category => category.Id)
            .ToListAsync(cancellationToken);

        return categories.ToResponse();
    }
}
