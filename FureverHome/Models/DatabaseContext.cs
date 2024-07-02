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

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies();
        if (optionsBuilder.IsConfigured) return;

        DotNetEnv.Env.Load("../.env"); // Works if the current directory is the LangLang project
        string connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING") ??
                                  throw new InvalidInputException("Connection string not found in .env file.");
        optionsBuilder.UseNpgsql(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // modelBuilder.Entity<Account>()
        //     .HasIndex(a => a.UserName)
        //     .IsUnique();

        modelBuilder.Entity<Account>()
            .HasOne(a => a.User)
            .WithOne()
            .HasForeignKey<Account>(a => a.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<AdoptionRequest>()
            .HasOne(ar => ar.Post)
            .WithMany(p => p.AdoptionRequests)
            .HasForeignKey(ar => ar.PostId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<AdoptionRequest>()
            .HasOne(ar => ar.User)
            .WithMany(u => u.AdoptionRequests)
            .HasForeignKey(ar => ar.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<AnimalBreed>()
            .HasOne(ab => ab.AnimalSpecies)
            .WithMany()
            .HasForeignKey(ab => ab.AnimalSpeciesId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<AnimalReview>()
            .HasOne(ar => ar.User)
            .WithMany()
            .HasForeignKey(ar => ar.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<AnimalReview>()
            .HasOne(ar => ar.Animal)
            .WithMany()
            .HasForeignKey(ar => ar.AnimalId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Comment>()
            .HasOne(c => c.User)
            .WithMany()
            .HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Comment>()
            .HasOne(c => c.Post)
            .WithMany(p => p.Comments)
            .HasForeignKey(c => c.PostId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Message>()
            .HasOne<RegisteredUser>()
            .WithMany(ru => ru.Messages)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Post>()
            .HasOne(p => p.Animal)
            .WithMany()
            .HasForeignKey(p => p.AnimalId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Post>()
            .HasOne(p => p.Author)
            .WithMany()
            .HasForeignKey(p => p.AuthorId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Post>()
            .HasMany(p => p.LikedBy)
            .WithMany();
    }
}