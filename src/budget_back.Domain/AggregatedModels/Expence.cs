namespace budget_back.Domain.AggregatedModels;

public class Expence
{
    public int Id { get; set; }
    public string Description { get; set; }
    public decimal Amount { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; } = null!;

    public Expence(string description, decimal amount, int categoryId)
    {
        Description = description;
        Amount = amount;
        CreatedAt = DateTime.UtcNow;
        CategoryId = categoryId;
    }
}