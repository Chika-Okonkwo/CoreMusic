using System.Collections.Generic;
using System.Threading.Tasks;
using CoreMusic.Core;
using CoreMusic.Core.Models;
using CoreMusic.Core.Services;

namespace CoreMusic.Services
{
  public class ArtistService : IArtistService
  {
    private readonly IUnitOfWork _unitOfWork;

    public ArtistService(IUnitOfWork unitOfWork)
    {
      this._unitOfWork = unitOfWork;
    }

    public async Task<Artist> CreateArtist(Artist newArtist)
    {
      await _unitOfWork.Artist
          .AddAsync(newArtist);

      await _unitOfWork.CommitAsync();

      return newArtist;
    }

    public async Task DeleteArtist(Artist artist)
    {
      _unitOfWork.Artist.Remove(artist);

      await _unitOfWork.CommitAsync();
    }

    public async Task<IEnumerable<Artist>> GetAllArtists()
    {
      return await _unitOfWork.Artist.GetAllAsync();
    }

    public async Task<Artist> GetArtistById(int id)
    {
      return await _unitOfWork.Artist.GetByIdAsync(id);
    }

    public async Task UpdateArtist(Artist artistToBeUpdated, Artist artist)
    {
      artistToBeUpdated.Name = artist.Name;

      await _unitOfWork.CommitAsync();
    }
  }
}