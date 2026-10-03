using Microsoft.EntityFrameworkCore;
using task3linq.models;

namespace task3linq
{
    public class BookstoreDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet <Author> Writers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>(entity =>
            {
                entity.Property(b => b.Title)
                      .IsRequired()
                      .HasMaxLength(150);
                entity.Property(b => b.Price)
                      .HasColumnType("decimal(8,2)");
                entity.Property(b => b.PublishedDate)
                      .IsRequired(false);
            });
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=BookstoreDb;Trusted_Connection=True;");
        }
    }
}
