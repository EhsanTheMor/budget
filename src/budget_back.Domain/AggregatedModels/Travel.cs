namespace budget_back.Domain.AggregatedModels;

public class Travel
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string? Description { get; private set; }

    public IReadOnlyList<Expence> Expences => _expences.AsReadOnly();
    private List<Expence> _expences = [];

    public IReadOnlyList<User> Users => _users.AsReadOnly();
    private List<User> _users = [];

}