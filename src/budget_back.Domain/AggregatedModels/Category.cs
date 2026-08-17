namespace budget_back.Domain.AggregatedModels;

public class Category
{
    public int Id { get; private set; }
    public string Name { get; private set; } = null!;
    public string Description { get; private set; } = null!;
    public string Type { get; private set; } = null!;
    public string Icon { get; private set; } = null!;
    public string Color { get; private set; } = null!;
    public int ExpenseScopeId { get; private set; }
    public ExpenseScope ExpenseScope { get; private set; } = null!;

    public Category(
        string name,
        string description,
        string type,
        string icon,
        string color)

    {
        Name = name;
        Description = description;
        Type = type;
        Icon = icon;
        Color = color;
        ExpenseScope = new ExpenseScope(ExpenseScopeType.Category);
    }

    public Expence AddExpence(string description, decimal amount, int? bankAccountId)
    {
        var expence = new Expence(description, amount, ExpenseScopeId, bankAccountId);
        ExpenseScope.AddExpence(expence);
        return expence;
    }
}


