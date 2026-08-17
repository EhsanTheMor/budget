namespace budget_back.Domain.AggregatedModels;

public class Travel
{
    public int Id { get; private set; }
    public string Name { get; private set; } = null!;
    public string? Description { get; private set; }
    public DateTime? StartDate { get; private set; }
    public DateTime? EndDate { get; private set; }
    public int ExpenseScopeId { get; private set; }
    public ExpenseScope ExpenseScope { get; private set; } = null!;
    public int ManagerId { get; private set; }
    public User Manager { get; private set; } = null!;
    public IReadOnlyList<User> Users => _users.AsReadOnly();
    private readonly List<User> _users = [];

    public Travel(int managerId, string name, string? description = null, DateTime? startDate = null, DateTime? endDate = null)
    {
        ManagerId = managerId;
        Name = name;
        Description = description;
        StartDate = startDate;
        EndDate = endDate;
        ExpenseScope = new ExpenseScope(ExpenseScopeType.Travel);
    }

    public Expence AddExpence(string description, decimal amount, int? bankAccountId)
    {
        var expence = new Expence(description, amount, ExpenseScopeId, bankAccountId);
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
