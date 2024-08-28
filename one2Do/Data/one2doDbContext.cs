using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using one2Do.Models;
using one2Do.Models.ToDoModels;
using one2Do.WeatherModel;

namespace one2Do.Data
{
    public class one2doDbContext : IdentityDbContext<User>
    {
        public one2doDbContext(DbContextOptions<one2doDbContext> options)
            : base(options) { }

        public DbSet<ToDoList> ToDoLists { get; set; }
        public DbSet<TaskItem> TaskItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<City>().ToTable("CityNames");

            //Added relations for the following entities

            modelBuilder
                .Entity<ToDoList>()
                .HasMany(t => t.TaskItems)
                .WithOne(t => t.ToDoList)
                .HasForeignKey(t => t.ToDoListId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder
                .Entity<TaskItem>()
                .HasOne(t => t.ToDoList)
                .WithMany(l => l.TaskItems)
                .HasForeignKey(t => t.ToDoListId);

            modelBuilder
                .Entity<Image>()
                .HasOne(i => i.User)
                .WithMany(i => i.Images)
                .HasForeignKey(i => i.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder
                .Entity<City>()
                .HasOne(c => c.User)
                .WithMany(c => c.Cities)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
