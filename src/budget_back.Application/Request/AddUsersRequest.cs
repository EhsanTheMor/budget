namespace budget_back.Application.Request;

public record AddUsersRequest(IReadOnlyList<int> UserIds);
