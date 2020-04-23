using System.Collections.Generic;
using System.Threading.Tasks;
using CoreMusic.Core;
using CoreMusic.Core.Models;
using CoreMusic.Core.Services;

namespace CoreMusic.Services
{
  public class MusicService : IMusicService
  {
    private readonly IUnitOfWork _unitOfWork;
    public MusicService(IUnitOfWork unitOfWork)
    {
      this._unitOfWork = unitOfWork;
    }

    public async Task<Music> CreateMusic(Music newMusic)
    {
      await _unitOfWork.Music.AddAsync(newMusic);
      await _unitOfWork.CommitAsync();
      return newMusic;
    }

    public async Task DeleteMusic(Music music)
    {
      _unitOfWork.Music.Remove(music);
      await _unitOfWork.CommitAsync();
    }

    public async Task<IEnumerable<Music>> GetAllWithArtist()
    {
      return await _unitOfWork.Music
          .GetAllWithArtistAsync();
    }

    public async Task<Music> GetMusicById(int id)
    {
      return await _unitOfWork.Music
          .GetWithArtistByIdAsync(id);
    }

    public async Task<IEnumerable<Music>> GetMusicsByArtistId(int artistId)
    {
      return await _unitOfWork.Music
          .GetAllWithArtistByArtistIdAsync(artistId);
    }

    public async Task UpdateMusic(Music musicToBeUpdated, Music music)
    {
      musicToBeUpdated.Name = music.Name;
      musicToBeUpdated.ArtistId = music.ArtistId;

      await _unitOfWork.CommitAsync();
    }
  }
}