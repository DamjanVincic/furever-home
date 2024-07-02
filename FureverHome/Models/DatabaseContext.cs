using Microsoft.EntityFrameworkCore;

namespace FureverHome.Models;

public class DatabaseContext : DbContext
{
    public DatabaseContext()
    {
    }
    
    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Account> Accounts { get; set; }
    public DbSet<Admin> Admins { get; set; }
    public DbSet<AdoptionRequest> AdoptionRequests { get; set; }
    public DbSet<Animal> Animals { get; set; }
    public DbSet<AnimalBreed> AnimalBreeds { get; set; }
    public DbSet<AnimalReview> AnimalReviews { get; set; }
    public DbSet<AnimalSpecies> AnimalSpecies { get; set; }
    public DbSet<Association> Associations { get; set; }
    public DbSet<Color> Colors { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Donation> Donations { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<RegisteredUser> RegisteredUsers { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Volunteer> Volunteers { get; set; }
    public DbSet<VolunteerApplication> VolunteerApplications { get; set; }

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