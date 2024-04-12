using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using YnovResurrection.Models;

namespace YnovResurrection;

public class AppDb : DbContext
{

    private readonly IConfiguration _configuration;

    public AppDb(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var serverVersion = ServerVersion.Parse("10.11.6-MariaDB");
        
        optionsBuilder.UseMySql(
            _configuration.GetConnectionString("DefaultConnection"),
            serverVersion
        );
    }

    public DbSet<School> Schools { get; set; }
    
    public DbSet<Building> Buildings { get; set; }
    
    public DbSet<Room> Rooms { get; set; }
    
    public DbSet<Equipment> Equipments { get; set; }
    
    public DbSet<Course> Courses { get; set; }
    
    public DbSet<Module> Modules { get; set; }
    
    public DbSet<User> Users { get; set; }
    
    public DbSet<StudentGroup> StudentGroups { get; set; }
    
}