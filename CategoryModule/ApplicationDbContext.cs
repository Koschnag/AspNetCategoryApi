using CategoryModule;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Category> Categories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            // Retrieve the connection string components from environment variables
            var host = Environment.GetEnvironmentVariable("POSTGRES_HOST") ?? "127.0.0.1";
            var database = Environment.GetEnvironmentVariable("POSTGRES_DB") ?? "categorydb";
            var username = Environment.GetEnvironmentVariable("POSTGRES_USER") ?? "postgres";
            var password = Environment.GetEnvironmentVariable("POSTGRES_PASSWORD") ?? "example";

            // Build the connection string
            var connectionString = $"Host={host};Database={database};Username={username};Password={password}";

            // Configure Npgsql with the connection string
            optionsBuilder.UseNpgsql(connectionString);
        }
    }
}