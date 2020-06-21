using Graduway.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Graduway.DAL
{
    public class GraduwayDbContext : DbContext
    {
        public GraduwayDbContext(DbContextOptions<GraduwayDbContext> options) : base(options)
        {
        }

        public GraduwayDbContext()
        {
        }

        DbSet<Employee> Employees { get; set; }
        DbSet<Task> Tasks { get; set; }
        DbSet<PriorityLevel> PriorityLevels { get; set; }
        DbSet<State> States { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(new Employee { Id = 1, FirstName = "John", LastName = "Smith", Department = "IT", Address = "Duncan Street", Title = "IT Manager", Tasks = null });

            modelBuilder.Entity<PriorityLevel>().HasData(new PriorityLevel { Id = 1, Priority = "Critical" });
            modelBuilder.Entity<PriorityLevel>().HasData(new PriorityLevel { Id = 2, Priority = "Medium" });
            modelBuilder.Entity<PriorityLevel>().HasData(new PriorityLevel { Id = 3, Priority = "Low" });

            modelBuilder.Entity<State>().HasData(new State { Id = 1, StateDescr = "New" });
            modelBuilder.Entity<State>().HasData(new State { Id = 2, StateDescr = "Active" });
            modelBuilder.Entity<State>().HasData(new State { Id = 3, StateDescr = "Resolved" });
            modelBuilder.Entity<State>().HasData(new State { Id = 4, StateDescr = "Closed" });

            base.OnModelCreating(modelBuilder);
        }
    }
}
