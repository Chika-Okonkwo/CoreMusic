using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreMusic.Core.Models;
using CoreMusic.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CoreMusic.Data.Repositories
{
  public class ArtistRepository : Repository<Artist>, IArtistRepository
  {
    public ArtistRepository(CoreMusicDbContext context)
           : base(context)
    { }

    public async Task<IEnumerable<Artist>> GetAllWithMusicsAsync()
    {
      return await MyMusicDbContext.Artist
          .Include(a => a.Music)
          .ToListAsync();
    }

    public Task<Artist> GetWithMusicsByIdAsync(int id)
    {
      return MyMusicDbContext.Artist
          .Include(a => a.Music)
          .SingleOrDefaultAsync(a => a.Id == id);
    }

    private CoreMusicDbContext MyMusicDbContext
    {
      get { return Context as CoreMusicDbContext; }
    }
  }
}