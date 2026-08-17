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
    public List<Travel> Travels { get; set; } = new List<Travel>();
    public List<Family> Families { get; set; } = new List<Family>();
    public List<Building> Buildings { get; set; } = new List<Building>();
    public IReadOnlyList<BankAccount> BankAccounts => _bankAccounts.AsReadOnly();
    private readonly List<BankAccount> _bankAccounts = [];

    public User(string name, string lastName, string username, string email, string password)
    {
        Name = name;
        LastName = lastName;
        Username = username;
        Email = email;
        Password = password;
        CreatedAt = DateTime.UtcNow;
    }

    public BankAccount AddBankAccount(string name, decimal initialBalance, string? bankName = null)
    {
        var bankAccount = new BankAccount(name, initialBalance, this, bankName);
        _bankAccounts.Add(bankAccount);
        return bankAccount;
    }
}