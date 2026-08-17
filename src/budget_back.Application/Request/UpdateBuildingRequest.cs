namespace budget_back.Application.Request;

public record UpdateBuildingRequest(
    string Name,
    int ManagerId,
    string? Description = null,
    string? Address = null);
