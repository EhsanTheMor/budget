namespace budget_back.Domain.AggregatedModels;

public class ExpenseScope
{
    public int Id { get; private set; }
    public ExpenseScopeType Type { get; private set; }
    public IReadOnlyList<Expence> Expences => _expences.AsReadOnly();
    private readonly List<Expence> _expences = [];

    public ExpenseScope(ExpenseScopeType type)
    {
        Type = type;
    }

    internal void AddExpence(Expence expence)
    {
        _expences.Add(expence);
    }
}
