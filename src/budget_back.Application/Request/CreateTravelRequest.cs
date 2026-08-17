namespace budget_back.Application.Request;

public record CreateTravelRequest(
    int ManagerId,
    string Name,
    string? Description = null,
    DateTime? StartDate = null,
    DateTime? EndDate = null);
