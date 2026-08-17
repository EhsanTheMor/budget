namespace budget_back.Domain.AggregatedModels;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public List<Category> Categories { get; set; } = new List<Category>();
    public User(string name, string lastName, string username, string email, string password)
    {
        Name = name;
        LastName = lastName;
        Username = username;
        Email = email;
        Password = password;
        CreatedAt = DateTime.UtcNow;
    }
}