namespace budget_back.Application.Response;

public record TravelResponse(
    int Id,
    string Name,
    string? Description,
    DateTime? StartDate,
    DateTime? EndDate,
    int ManagerId,
    int ExpenseScopeId,
    IReadOnlyList<int> UserIds);
