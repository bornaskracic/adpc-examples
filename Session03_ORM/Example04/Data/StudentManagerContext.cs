using Microsoft.EntityFrameworkCore;

namespace Example04.Data;
public class StudentManagerContext : DbContext
{
    public const string CONNECTION_STRING =
        "Host=localhost;Port=5432;Username=postgres;Password=password;Database=postgres;";
    public DbSet<Student> Students {get; set;}
    public DbSet<Group> Groups {get; set;}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder
            .UseNpgsql(CONNECTION_STRING)
            .EnableSensitiveDataLogging()
            .LogTo(Console.WriteLine);
}