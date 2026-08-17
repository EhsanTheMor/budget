namespace budget_back.Application.Response;

public record FamilyResponse(
    int Id,
    string Name,
    string? Description,
    int ManagerId,
    int ExpenseScopeId,
    IReadOnlyList<int> UserIds);
