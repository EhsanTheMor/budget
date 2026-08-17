namespace budget_back.Application.Response;

public record CategoryResponse(
    int Id,
    string Name,
    string Description,
    string Type,
    string Icon,
    string Color,
    int ExpenseScopeId);
