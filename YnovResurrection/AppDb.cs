using Microsoft.EntityFrameworkCore;
using YnovResurrection.Models;

namespace YnovResurrection;

public class AppDb : DbContext
{

    public DbSet<School> Schools { get; set; }

    public DbSet<Building> Buildings { get; set; }

    public DbSet<Room> Rooms { get; set; }

    public DbSet<Equipment> Equipments { get; set; }

    public DbSet<Course> Courses { get; set; }

    public DbSet<Module> Modules { get; set; }

    public DbSet<User> Users { get; set; }

    public DbSet<StudentGroup> StudentGroups { get; set; }

}