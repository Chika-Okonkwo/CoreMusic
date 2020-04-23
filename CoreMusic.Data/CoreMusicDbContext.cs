using CoreMusic.Core.Models;
using CoreMusic.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CoreMusic.Data
{
  public class CoreMusicDbContext : DbContext
  {
    public DbSet<Music> Music { get; set; }
    public DbSet<Artist> Artist { get; set; }

    public CoreMusicDbContext(DbContextOptions<CoreMusicDbContext> options)
        : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      //builder
      //    .ApplyConfiguration(new MusicConfiguration());

      //builder
      //    .ApplyConfiguration(new ArtistConfiguration());

      // apply all congfig found in this assembly

      base.OnModelCreating(builder);
      builder.ApplyConfigurationsFromAssembly(assembly: Assembly.GetExecutingAssembly());

    }
  }
}
