namespace budget_back.Domain.AggregatedModels;

public class Building
{
    public int Id { get; private set; }
    public string Name { get; private set; } = null!;
    public string? Description { get; private set; }
    public string? Address { get; private set; }
    public int ExpenseScopeId { get; private set; }
    public ExpenseScope ExpenseScope { get; private set; } = null!;
    public int ManagerId { get; private set; }
    public User Manager { get; private set; } = null!;
    public IReadOnlyList<User> Users => _users.AsReadOnly();
    private readonly List<User> _users = [];

    public Building(string name, User manager, string? description = null, string? address = null)
    {
        Name = name;
        Description = description;
        Address = address;
        Manager = manager;
        ExpenseScope = new ExpenseScope(ExpenseScopeType.Building);
        _users.Add(manager);
    }

    public Expence AddExpence(string description, decimal amount, int? bankAccountId)
    {
        var expence = new Expence(description, amount, ExpenseScope, bankAccountId);
        ExpenseScope.AddExpence(expence);
        return expence;
    }

    public void AddUser(User user)
    {
        if (!_users.Contains(user))
        {
            _users.Add(user);
        }
    }

    public void SetManager(User user)
    {
        AddUser(user);
        Manager = user;
    }
}
