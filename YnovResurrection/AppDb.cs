using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using YnovResurrection.Models;

namespace YnovResurrection;

public class AppDb(IConfiguration configuration) : DbContext
{

    private readonly IConfiguration _configuration = configuration;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(_configuration.GetConnectionString("DefaultConnection"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Building>()
            .ToTable(typeof(Building).Name + "s")
            .HasKey(lf => new { lf.Id });

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<School> Schools { get; set; }

    public DbSet<Building> Buildings { get; set; }

    public DbSet<Room> Rooms { get; set; }

    public DbSet<Equipment> Equipments { get; set; }

    public DbSet<Course> Courses { get; set; }

    public DbSet<Module> Modules { get; set; }

    public DbSet<User> Users { get; set; }

    public DbSet<StudentGroup> StudentGroups { get; set; }

    public void InitializeDatabase()
    {
        using var context = new AppDb(configuration);
        try
        {
            // Appliquer les migrations
            //context.Database.EnsureDeleted();
            var isCreated = context.Database.EnsureCreated();
            if (isCreated)
            {
                // TODO: add Data for Building
                var buildings = new List<Building>
                {
                    new() { Address = "123 Main St" },
                    new() { Address = "456 Elm St" },
                    new() { Address = "789 Oak St" }
                };

                // Ajout des bâtiments au contexte
                context.Buildings.AddRange(buildings);

                // Enregistrement des changements dans la base de données
                context.SaveChanges();
            }
            Console.WriteLine("La base de données a été migrée avec succès.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erreur lors de la migration de la base de données : " + ex.Message);
        }
    }

}