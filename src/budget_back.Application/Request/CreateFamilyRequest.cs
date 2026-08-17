namespace budget_back.Application.Request;

public record CreateFamilyRequest(
    string Name,
    int ManagerId,
    string? Description = null);
