namespace budget_back.Application.Request;

public record UpdateTravelRequest(
    int ManagerId,
    string Name,
    string? Description = null,
    DateTime? StartDate = null,
    DateTime? EndDate = null);
