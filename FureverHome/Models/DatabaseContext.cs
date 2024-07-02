using Microsoft.EntityFrameworkCore;

namespace FureverHome.Models;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies();
        if (optionsBuilder.IsConfigured) return;
        
        DotNetEnv.Env.Load("../.env"); // Works if the current directory is the LangLang project
        string connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING") ?? throw new InvalidInputException("Connection string not found in .env file.");
        optionsBuilder.UseNpgsql(connectionString);
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}