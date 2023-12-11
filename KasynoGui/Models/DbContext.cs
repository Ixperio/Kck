using KasynoGui.Models;
using System.Data.Entity;

public class YourDbContext : DbContext
{
    public YourDbContext() : base("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\alok1\\Desktop\\STUDIA\\SEM5\\kck\\KasynoGui\\App_Data\\Database.mdf;Integrated Security=True")
    {
        // Konstruktor, ustaw nazwę połączenia (Connection String) zdefiniowaną w pliku konfiguracyjnym
    }

    public DbSet<UserModel> Uzytkownik { get; set; }
    public DbSet<Ruletka> Ruletka { get; set; }
    public DbSet<RuletkaBets> RuletkaBets { get; set; }
    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        // Dodatkowe konfiguracje modelu, jeśli są wymagane
    }
}