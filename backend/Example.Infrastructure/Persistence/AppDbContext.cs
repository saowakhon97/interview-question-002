using Example.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Example.Infrastructure.Persistence;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(x => x.Id);

            entity.Property(x => x.Username)
                .HasMaxLength(100)
                .IsRequired();

            entity.HasIndex(x => x.Username)
                .IsUnique();

            entity.Property(x => x.PasswordHash)
                .IsRequired();

            // entity.Property(x => x.DisplayName)
                // .HasMaxLength(200);
        });
    }
}