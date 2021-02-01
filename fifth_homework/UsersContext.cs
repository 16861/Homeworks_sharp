using Microsoft.EntityFrameworkCore;

namespace project {
    public class UsersContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Filename=mydb.sqlite3");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Car>()
            .HasIndex(p => new { p.Model })
            .IsUnique();
        
        modelBuilder.Entity<Manufacturer>()
            .HasIndex(p => new { p.Name })
            .IsUnique();
    }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
    }
}