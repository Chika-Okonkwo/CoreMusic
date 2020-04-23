using System.Threading.Tasks;
using CoreMusic.Core;
using CoreMusic.Core.Repositories;
using CoreMusic.Data.Repositories;

namespace CoreMusic.Data
{
  public class UnitOfWork : IUnitOfWork
  {
    private readonly CoreMusicDbContext _context;
    private MusicRepository _musicRepository;
    private ArtistRepository _artistRepository;

    public UnitOfWork(CoreMusicDbContext context)
    {
      this._context = context;
    }

    public IMusicRepository Music => _musicRepository = _musicRepository ?? new MusicRepository(_context);

    public IArtistRepository Artist => _artistRepository = _artistRepository ?? new ArtistRepository(_context);

    public async Task<int> CommitAsync()
    {
      return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
      _context.Dispose();
    }
  }
}