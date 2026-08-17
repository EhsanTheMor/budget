namespace budget_back.Domain.AggregatedModels;

public class BankAccount
{
    public int Id { get; private set; }
    public string Name { get; private set; } = null!;
    public string? BankName { get; private set; }
    public decimal InitialBalance { get; private set; }
    public int UserId { get; private set; }
    public User User { get; private set; } = null!;

    public IReadOnlyList<Expence> Expences => _expences.AsReadOnly();
    private readonly List<Expence> _expences = [];

    public decimal RemainingBalance => InitialBalance - _expences.Sum(expence => expence.Amount);

    private BankAccount()
    {
    }

    public BankAccount(string name, decimal initialBalance, User user, string? bankName = null)
    {
        Name = name;
        InitialBalance = initialBalance;
        User = user;
        BankName = bankName;
    }

    internal void AddExpence(Expence expence)
    {
        _expences.Add(expence);
    }
}
