using CoreMusic.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoreMusic.Data.Configurations
{
  public class ArtistConfiguration : IEntityTypeConfiguration<Artist>
  {
    public void Configure(EntityTypeBuilder<Artist> builder)
    {
      builder
          .HasKey(a => a.Id);

      builder
          .Property(m => m.Id)
          .UseIdentityColumn();

      builder
          .Property(m => m.Name)
          .IsRequired()
          .HasMaxLength(50);

      builder
          .ToTable("Artist");
    }
  }
}