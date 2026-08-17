namespace budget_back.Domain.AggregatedModels;

public class Category
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public string Type { get; private set; }
    public string Icon { get; private set; }
    public string Color { get; private set; }
    public CategoryCreationType CategoryCreationType { get; private set; }

    public IReadOnlyList<Expence> Expences => _expences.AsReadOnly();
    private List<Expence> _expences = new List<Expence>();

    public Category(
        string name,
        string description,
        string type,
        string icon,
        string color,
        CategoryCreationType categoryCreationType = CategoryCreationType.User
        )
    {
        Name = name;
        Description = description;
        Type = type;
        Icon = icon;
        Color = color;
        CategoryCreationType = categoryCreationType;
    }

    public void AddExpence(Expence expence)
    {
        _expences.Add(expence);
    }
}