using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreMusic.Core.Models;
using CoreMusic.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CoreMusic.Data.Repositories
{
  public class MusicRepository : Repository<Music>, IMusicRepository
  {
    public MusicRepository(CoreMusicDbContext context)
       : base(context)
    { }

    public async Task<IEnumerable<Music>> GetAllWithArtistAsync()
    {
      return await MyMusicDbContext.Music
          .Include(m => m.Artist)
          .ToListAsync();
    }

    public async Task<Music> GetWithArtistByIdAsync(int id)
    {
      return await MyMusicDbContext.Music
          .Include(m => m.Artist)
          .SingleOrDefaultAsync(m => m.Id == id); ;
    }

    public async Task<IEnumerable<Music>> GetAllWithArtistByArtistIdAsync(int artistId)
    {
      return await MyMusicDbContext.Music
          .Include(m => m.Artist)
          .Where(m => m.ArtistId == artistId)
          .ToListAsync();
    }

    private CoreMusicDbContext MyMusicDbContext
    {
      get { return Context as CoreMusicDbContext; }
    }
  }
}