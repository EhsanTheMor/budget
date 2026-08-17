namespace budget_back.Application.Request;

public record CreateCategoryRequest(
    string Name,
    string Description,
    string Type,
    string Icon,
    string Color);
