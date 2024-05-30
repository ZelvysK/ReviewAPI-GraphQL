using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ReviewApp.API.Types.Base;
using ReviewApp.API.Types.Enums;

namespace ReviewApp.API;

public class ReviewContext(DbContextOptions<ReviewContext> options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.UseNpgsql("Host=my_host;Database=my_db;Username=my_user;Password=my_pw");

    public DbSet<Studio> Studios { get; set; }
    public DbSet<Media> Media { get; set; }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Studio>(entity =>
        {
            entity.Property(e => e.Type).HasConversion(new EnumToStringConverter<StudioType>());
        });

        modelBuilder.Entity<Media>(entity =>
        {
            entity.Property(e => e.MediaType).HasConversion(new EnumToStringConverter<MediaType>());
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.Role).HasConversion(new EnumToStringConverter<UserRole>());
        });

        base.OnModelCreating(modelBuilder);
    }
}
