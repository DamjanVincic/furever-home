using Microsoft.Extensions.DependencyInjection;

namespace FureverHome.Models;

public class ServiceProvider
{
    public static IServiceProvider Instance { get; set; }
    
    public static T GetRequiredService<T>() where T : notnull => Instance.GetRequiredService<T>();
}