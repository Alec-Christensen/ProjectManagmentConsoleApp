using Microsoft.EntityFrameworkCore;
using ProjectManagmentConsoleApp.Entities;

namespace ProjectManagmentConsoleApp.Data;

public class AppDbContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Project> Projects { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ProjectManagementDb;Trusted_Connection=True;");
    }
}
