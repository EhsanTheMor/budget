using budget_back.Application.Abstractions.Persist;
using budget_back.Application.Mappings;
using budget_back.Application.Response;
using budget_back.Domain.AggregatedModels;
using MediatR;

namespace budget_back.Application.Features.Categories;

public record CreateCategoryCommand(
    string Name,
    string Description,
    string Type,
    string Icon,
    string Color) : IRequest<CategoryResponse>;

public class CreateCategoryCommandHandler(IBudgetDbContext context)
    : IRequestHandler<CreateCategoryCommand, CategoryResponse>
{
    public async Task<CategoryResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = new Category(request.Name, request.Description, request.Type, request.Icon, request.Color);
        await context.Categories.AddAsync(category, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        return category.ToResponse();
    }
}
