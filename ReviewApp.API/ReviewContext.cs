using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ReviewApp.API.Types;
using ReviewApp.API.Types.Enums;

namespace ReviewApp.API;

public class ReviewContext(DbContextOptions<ReviewContext> options) : DbContext(options)
{
    public DbSet<Studio> Studios { get; set; }
    public DbSet<Media> Media { get; set; }

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

        base.OnModelCreating(modelBuilder);
    }
}
