namespace budget_back.Application.Response;

public record BuildingResponse(
    int Id,
    string Name,
    string? Description,
    string? Address,
    int ManagerId,
    int ExpenseScopeId,
    IReadOnlyList<int> UserIds);
