namespace budget_back.Application.Request;

public record CreateBuildingRequest(
    string Name,
    int ManagerId,
    string? Description = null,
    string? Address = null);
