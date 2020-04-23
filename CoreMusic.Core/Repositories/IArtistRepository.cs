using System.Collections.Generic;
using System.Threading.Tasks;
using CoreMusic.Core.Models;

namespace CoreMusic.Core.Repositories
{
  public interface IArtistRepository : IRepository<Artist>
  {
    Task<IEnumerable<Artist>> GetAllWithMusicsAsync();
    Task<Artist> GetWithMusicsByIdAsync(int id);
  }
}
