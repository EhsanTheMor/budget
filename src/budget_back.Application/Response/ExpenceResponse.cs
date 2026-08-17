namespace budget_back.Application.Response;

public record ExpenceResponse(
    int Id,
    string Description,
    decimal Amount,
    DateTime CreatedAt,
    DateTime? UpdatedAt,
    int ExpenseScopeId,
    int? BankAccountId);
