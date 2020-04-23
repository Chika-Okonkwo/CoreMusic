
using System.Collections.Generic;
using System.Threading.Tasks;
using CoreMusic.Core.Models;

namespace CoreMusic.Core.Repositories
{
  public interface IMusicRepository : IRepository<Music>
  {
    Task<IEnumerable<Music>> GetAllWithArtistAsync();
    Task<Music> GetWithArtistByIdAsync(int id);
    Task<IEnumerable<Music>> GetAllWithArtistByArtistIdAsync(int artistId);
  }
}
