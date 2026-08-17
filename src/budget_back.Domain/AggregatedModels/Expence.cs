namespace budget_back.Domain.AggregatedModels;

public class Expence
{
    public int Id { get; private set; }
    public string Description { get; private set; } = null!;
    public decimal Amount { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    public int ExpenseScopeId { get; private set; }
    public ExpenseScope ExpenseScope { get; private set; } = null!;
    public int? BankAccountId { get; private set; }
    public BankAccount? BankAccount { get; private set; }

    public Expence(
        string description,
        decimal amount,
        int expenseScopeId,
        int? bankAccountId)
    {
        Description = description;
        Amount = amount;
        ExpenseScopeId = expenseScopeId;
        CreatedAt = DateTime.UtcNow;
        BankAccountId = bankAccountId;
    }

    public void AttachToBankAccount(int bankAccountId)
    {
        BankAccountId = bankAccountId;
    }
}
