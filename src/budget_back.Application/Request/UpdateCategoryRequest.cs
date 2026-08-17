namespace budget_back.Application.Request;

public record UpdateCategoryRequest(
    string Name,
    string Description,
    string Type,
    string Icon,
    string Color);
