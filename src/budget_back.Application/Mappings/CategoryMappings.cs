using budget_back.Application.Features.Categories;
using budget_back.Application.Request;
using budget_back.Application.Response;
using budget_back.Domain.AggregatedModels;

namespace budget_back.Application.Mappings;

public static class CategoryMappings
{
    public static CreateCategoryCommand ToCommand(this CreateCategoryRequest request)
    {
        return new CreateCategoryCommand(
            request.Name,
            request.Description,
            request.Type,
            request.Icon,
            request.Color);
    }

    public static UpdateCategoryCommand ToCommand(this UpdateCategoryRequest request, int id)
    {
        return new UpdateCategoryCommand(
            id,
            request.Name,
            request.Description,
            request.Type,
            request.Icon,
            request.Color);
    }

    public static AddExpenceToCategoryCommand ToAddExpenceToCategoryCommand(this AddExpenceRequest request, int id)
    {
        return new AddExpenceToCategoryCommand(id, request.Description, request.Amount, request.BankAccountId);
    }

    public static CategoryResponse ToResponse(this Category category)
    {
        return new CategoryResponse(
            category.Id,
            category.Name,
            category.Description,
            category.Type,
            category.Icon,
            category.Color,
            category.ExpenseScopeId);
    }

    public static IReadOnlyList<CategoryResponse> ToResponse(this IEnumerable<Category> categories)
    {
        return categories.Select(ToResponse).ToList();
    }
}
