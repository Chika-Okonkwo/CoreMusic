using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CoreMusic.Api.Resources;
using CoreMusic.Core.Models;
using CoreMusic.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace CoreMusic.Api
{
  [Route("api/musics")]
  [ApiController]
  public class MusicController : ControllerBase
  {
    private readonly IMusicService _musicService;
    private readonly IMapper _mapper;
    public MusicController(IMusicService musicService, IMapper mapper)
    {
      _musicService = musicService;
      _mapper = mapper;
    }
    [HttpGet("")]
    public async Task<ActionResult<IEnumerable<MusicResource>>> GetAllMusics()
    {
      var musics = await _musicService.GetAllWithArtist();
      var musicResources = _mapper.Map<IEnumerable<MusicResource>>(musics);

      return Ok(musicResources);
    }

    [HttpPost("")]
    public async Task<ActionResult<MusicResource>> CreateMusic([FromBody] SaveMusicResource saveMusicResource)
    {
      if (!ModelState.IsValid) 
        return BadRequest(ModelState); // this needs refining, but for demo it is ok

      var musicToCreate = _mapper.Map<Music>(saveMusicResource);

      var newMusic = await _musicService.CreateMusic(musicToCreate);

      var music = await _musicService.GetMusicById(newMusic.Id);

      var musicResource = _mapper.Map<MusicResource>(music);

      return Ok(musicResource);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<MusicResource>> GetMusicById(int id)
    {
      var music = await _musicService.GetMusicById(id);
      var musicResource = _mapper.Map<MusicResource>(music);

      return Ok(musicResource);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<MusicResource>> UpdateMusic(int id, [FromBody] SaveMusicResource saveMusicResource)
    {
      var requestIsInvalid = id == 0 || !ModelState.IsValid;

      if (requestIsInvalid)
        return BadRequest(ModelState); // this needs refining, but for demo it is ok

      var musicToBeUpdate = await _musicService.GetMusicById(id);

      if (musicToBeUpdate == null)
        return NotFound();

      var music = _mapper.Map<Music>(saveMusicResource);

      await _musicService.UpdateMusic(musicToBeUpdate, music);

      var updatedMusic = await _musicService.GetMusicById(id);
      var updatedMusicResource = _mapper.Map<MusicResource>(updatedMusic);

      return Ok(updatedMusicResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMusic(int id)
    {
      if (id == 0)
        return BadRequest();

      var music = await _musicService.GetMusicById(id);

      if (music == null)
        return NotFound();

      await _musicService.DeleteMusic(music);

      return NoContent();
    }
  }
}