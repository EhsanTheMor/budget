namespace budget_back.Domain.AggregatedModels;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Type { get; set; }
    public string Icon { get; set; }
    public string Color { get; set; }
}