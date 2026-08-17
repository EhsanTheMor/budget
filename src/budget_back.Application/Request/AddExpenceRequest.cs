namespace budget_back.Application.Request;

public record AddExpenceRequest(
    string Description,
    decimal Amount,
    int? BankAccountId = null);
