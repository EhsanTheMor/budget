namespace budget_back.Application.Request;

public record UpdateFamilyRequest(
    string Name,
    int ManagerId,
    string? Description = null);
