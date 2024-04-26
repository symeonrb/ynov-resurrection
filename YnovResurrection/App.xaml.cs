using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using YnovResurrection.Services;

namespace YnovResurrection;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public static App Me => ((App)Application.Current);
    public IServiceProvider ServiceProvider { get; private set; }
    public string MyProperty { get; set; }
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        // Configuration de l'injection de dépendances
        var serviceCollection = new ServiceCollection();
        ConfigureServices(serviceCollection);

        // Création du ServiceProvider
        ServiceProvider = serviceCollection.BuildServiceProvider();

        // Récupération du contexte de base de données
        var appDb = ServiceProvider.GetRequiredService<AppDb>();

        // Initialisation de la base de données
        appDb.InitializeDatabase();
    }


    private static void ConfigureServices(IServiceCollection services)
    {
        // Configuration de l'accès à la base de données
        IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        services.AddSingleton(configuration);
        services.AddDbContext<AppDb>();

        // Enregistrez vos services ici
        services.AddScoped<BuildingService>();
        services.AddScoped<CourseService>();
        services.AddScoped<EquipmentService>();
        services.AddScoped<ModuleService>();
        services.AddScoped<RoomService>();
        services.AddScoped<SchoolService>();
        services.AddScoped<StudentGroupService>();
        services.AddScoped<UserService>();

    }
}