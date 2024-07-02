using System.Windows;
using FureverHome.Models;
using FureverHome.Repositories;
using FureverHome.Repositories.PostgresRepositories;
using FureverHome.Services;
using FureverHome.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ServiceProvider = FureverHome.Models.ServiceProvider;

namespace FureverHome;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public App()
    {
        DotNetEnv.Env.Load("../.env");

        ServiceCollection services = new ServiceCollection();
        ConfigureServices(services);
        
        ServiceProvider.Instance = services.BuildServiceProvider();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
        mainWindow.Show();
    }

    private void ConfigureServices(IServiceCollection services)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        
        string connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING") ?? throw new InvalidInputException("Connection string not found in .env file.");
        services.AddDbContext<DatabaseContext>(options => options.UseNpgsql(connectionString));

        services.AddScoped<MainWindow>();

        services.AddScoped<IAccountRepository, AccountPostgresRepository>();
        services.AddScoped<IAdoptionRequestRepository, AdoptionRequestPostgresRepository>();
        services.AddScoped<IAnimalBreedRepository, AnimalBreedPostgresRepository>();
        services.AddScoped<IAnimalRepository, AnimalPostgresRepository>();
        services.AddScoped<IAnimalReviewRepository, AnimalReviewPostgresRepository>();
        services.AddScoped<IAnimalSpeciesRepository, AnimalSpeciesPostgresRepository>();
        services.AddScoped<IAssociationRepository, AssociationPostgresRepository>();
        services.AddScoped<IColorRepository, ColorPostgresRepository>();
        services.AddScoped<ICommentRepository, CommentPostgresRepository>();
        services.AddScoped<IMessageRepository, MessagePostgresRepository>();
        services.AddScoped<IPostRepository, PostPostgresRepository>();
        services.AddScoped<IUserRepository, UserPostgresRepository>();
        services.AddScoped<UserService, UserService>();
    }
}