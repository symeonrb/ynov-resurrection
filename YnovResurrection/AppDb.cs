using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using YnovResurrection.Models;
using YnovResurrection.Services;

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
            // context.Database.EnsureDeleted();
            var isCreated = context.Database.EnsureCreated();
            if (isCreated)
            {
                // Add schools
                // var schools = new List<School>
                // {
                //     new() { Id = Guid.NewGuid().ToString(), Name = "MusicHouse" },
                //     new() { Id = Guid.NewGuid().ToString(), Name = "NobodyNovy" }
                // };
                // context.Schools.AddRange(schools);

                // Add student groups
                // var studentGroups = new List<StudentGroup>
                // {
                //     new() { Id = Guid.NewGuid().ToString(), Name = "Bachelor 1", School = schools[0] },
                //     new() { Id = Guid.NewGuid().ToString(), Name = "Bachelor 2", School = schools[0] },
                //     new() { Id = Guid.NewGuid().ToString(), Name = "Students learning French", School = schools[0] }
                // };
                // context.StudentGroups.AddRange(studentGroups);

                // Add users
                // var users = new List<User>
                // {
                //     new() { Id = Guid.NewGuid().ToString(), FirstName = "Ben", LastName = "Johnson", StudentGroups = new[] { studentGroups[0], studentGroups[2] } },
                //     new() { Id = Guid.NewGuid().ToString(), FirstName = "Job", LastName = "Smith" },
                //     new() { Id = Guid.NewGuid().ToString(), FirstName = "Tom", LastName = "Harris" },
                //     new() { Id = Guid.NewGuid().ToString(), FirstName = "Ana", LastName = "Rodriguez" },
                //     new() { Id = Guid.NewGuid().ToString(), FirstName = "Tea", LastName = "Lee" },
                //     new() { Id = Guid.NewGuid().ToString(), FirstName = "Zoe", LastName = "Brown" },
                //     new() { Id = Guid.NewGuid().ToString(), FirstName = "Pol", LastName = "Davis" },
                //     new() { Id = Guid.NewGuid().ToString(), FirstName = "Duh", LastName = "Wilson" },
                //     new() { Id = Guid.NewGuid().ToString(), FirstName = "Albert", LastName = "Martin", StudentGroups = new[] { studentGroups[1], studentGroups[2] } },
                //     new() { Id = Guid.NewGuid().ToString(), FirstName = "Enrico", LastName = "Perez" },
                //     new() { Id = Guid.NewGuid().ToString(), FirstName = "Sirena", LastName = "Gomez" },
                //     new() { Id = Guid.NewGuid().ToString(), FirstName = "Duhduh", LastName = "Hall" },
                //     new() { Id = Guid.NewGuid().ToString(), FirstName = "Director", LastName = "Admin", IsSuperAdmin = true },
                //     new() { Id = Guid.NewGuid().ToString(), FirstName = "ComputerGuy", LastName = "Tech", IsSuperAdmin = true },
                //     new() { Id = Guid.NewGuid().ToString(), FirstName = "TeacherBanjo", LastName = "Banjo" },
                //     new() { Id = Guid.NewGuid().ToString(), FirstName = "TeacherDJ", LastName = "DJ" },
                //     new() { Id = Guid.NewGuid().ToString(), FirstName = "TeacherGuitar", LastName = "Guitar" },
                //     new() { Id = Guid.NewGuid().ToString(), FirstName = "TeacherFrench", LastName = "French" }
                // };
                // context.Users.AddRange(users);

                // Add modules
                // var modules = new List<Module>
                // {
                //     new() { Id = Guid.NewGuid().ToString(), Name = "Banjo", TotalHours = 3, Teacher = users[12], StudentGroup = studentGroups[0], School = schools[0] },
                //     new() { Id = Guid.NewGuid().ToString(), Name = "DJ", TotalHours = 3, Teacher = users[13], StudentGroup = studentGroups[1], School = schools[0] },
                //     new() { Id = Guid.NewGuid().ToString(), Name = "GuitareB1", TotalHours = 3, Teacher = users[14], StudentGroup = studentGroups[0], School = schools[0] },
                //     new() { Id = Guid.NewGuid().ToString(), Name = "GuitareB2", TotalHours = 3, Teacher = users[14], StudentGroup = studentGroups[1], School = schools[0] },
                //     new() { Id = Guid.NewGuid().ToString(), Name = "Français", TotalHours = 3, Teacher = users[15], StudentGroup = studentGroups[2], School = schools[0] },
                //     new() { Id = Guid.NewGuid().ToString(), Name = "Concours d'éloquence", TotalHours = 3, Teacher = users[15], StudentGroup = studentGroups[2], School = schools[1] }
                // };
                // context.Modules.AddRange(modules);

                // Add courses
                // var courses = new List<Course>
                // {
                //     new() { Id = Guid.NewGuid().ToString(), Module = modules[0], StartTime = new DateTime(2024, 9, 15, 9, 0, 0), EndTime = new DateTime(2024, 9, 15, 12, 0, 0) },
                //     new() { Id = Guid.NewGuid().ToString(), Module = modules[0], StartTime = new DateTime(2024, 9, 15, 13, 30, 0), EndTime = new DateTime(2024, 9, 15, 16, 30, 0) },
                //     new() { Id = Guid.NewGuid().ToString(), Module = modules[1], StartTime = new DateTime(2024, 9, 15, 9, 0, 0), EndTime = new DateTime(2024, 9, 15, 12, 0, 0) },
                //     new() { Id = Guid.NewGuid().ToString(), Module = modules[1], StartTime = new DateTime(2024, 9, 15, 13, 30, 0), EndTime = new DateTime(2024, 9, 15, 16, 30, 0) },
                //     new() { Id = Guid.NewGuid().ToString(), Module = modules[2], StartTime = new DateTime(2024, 9, 16, 9, 0, 0), EndTime = new DateTime(2024, 9, 16, 12, 0, 0) },
                //     new() { Id = Guid.NewGuid().ToString(), Module = modules[2], StartTime = new DateTime(2024, 9, 16, 13, 30, 0), EndTime = new DateTime(2024, 9, 16, 16, 30, 0) },
                //     new() { Id = Guid.NewGuid().ToString(), Module = modules[3], StartTime = new DateTime(2024, 9, 17, 9, 0, 0), EndTime = new DateTime(2024, 9, 17, 12, 0, 0) },
                //     new() { Id = Guid.NewGuid().ToString(), Module = modules[3], StartTime = new DateTime(2024, 9, 17, 13, 30, 0), EndTime = new DateTime(2024, 9, 17, 16, 30, 0) },
                //     new() { Id = Guid.NewGuid().ToString(), Module = modules[4], StartTime = new DateTime(2024, 9, 17, 9, 0, 0), EndTime = new DateTime(2024, 9, 17, 12, 0, 0) },
                //     new() { Id = Guid.NewGuid().ToString(), Module = modules[4], StartTime = new DateTime(2024, 9, 17, 13, 30, 0), EndTime = new DateTime(2024, 9, 17, 16, 30, 0) },
                //     new() { Id = Guid.NewGuid().ToString(), Module = modules[5], StartTime = new DateTime(2024, 9, 17, 13, 30, 0), EndTime = new DateTime(2024, 9, 17, 16, 30, 0) }
                // };
                // context.Courses.AddRange(courses);

                // Add buildings
                var schools = SchoolService.Instance.List();
                var buildings = new List<Building>
                {
                    new() { Id = Guid.NewGuid().ToString(), Address = "1 Swing St", School = null },
                    new() { Id = Guid.NewGuid().ToString(), Address = "2 Swing St", School = null },
                    new() { Id = Guid.NewGuid().ToString(), Address = "000 Nowhere St", School = null }
                };
                context.Buildings.AddRange(buildings);

                // Add rooms
                // var rooms = new List<Room>
                // {
                //     new() { Id = Guid.NewGuid().ToString(), Name = "a101", Building = buildings[0] },
                //     new() { Id = Guid.NewGuid().ToString(), Name = "a102", Building = buildings[0] },
                //     new() { Id = Guid.NewGuid().ToString(), Name = "a103", Building = buildings[0] },
                //     new() { Id = Guid.NewGuid().ToString(), Name = "b101", Building = buildings[1] },
                //     new() { Id = Guid.NewGuid().ToString(), Name = "b102", Building = buildings[1] },
                //     new() { Id = Guid.NewGuid().ToString(), Name = "Amphitheater", Building = buildings[2] }
                // };
                // context.Rooms.AddRange(rooms);

                // Add equipment
                // var equipment = new List<Equipment>
                // {
                //     new() { Id = Guid.NewGuid().ToString(), Type = Equipment.ChairType },
                //     new() { Id = Guid.NewGuid().ToString(), Type = Equipment.Table1PersonType },
                //     new() { Id = Guid.NewGuid().ToString(), Type = Equipment.Table2PeopleType }
                // };
                // context.Equipments.AddRange(equipment);

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
