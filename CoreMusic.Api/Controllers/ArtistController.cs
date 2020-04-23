using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CoreMusic.Api.Resources;
using CoreMusic.Core.Models;
using CoreMusic.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace CoreMusic.Api
{
  [Route("api/artists")]
  [ApiController]
  public class ArtistController : ControllerBase
  {
    private readonly IArtistService _artistService;
    private readonly IMapper _mapper;

    public ArtistController(IArtistService artistService, IMapper mapper)
    {
      _mapper = mapper;
      _artistService = artistService;
    }

    [HttpGet("")]
    public async Task<ActionResult<IEnumerable<ArtistResource>>> GetAllArtists()
    {
      var artists = await _artistService.GetAllArtists();
      var artistResources = _mapper.Map<IEnumerable<ArtistResource>>(artists);

      return Ok(artistResources);
    }

    [HttpPost("")]
    public async Task<ActionResult<ArtistResource>> CreateArtist([FromBody] SaveArtistResource saveArtistResource)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState); // this needs refining, but for demo it is ok

      var artistToCreate = _mapper.Map<Artist>(saveArtistResource);

      var newArtist = await _artistService.CreateArtist(artistToCreate);

      var artist = await _artistService.GetArtistById(newArtist.Id);

      var artistResource = _mapper.Map<ArtistResource>(artist);

      return Ok(artistResource);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ArtistResource>> GetArtistById(int id)
    {
      var artist = await _artistService.GetArtistById(id);
      var artistResource = _mapper.Map<ArtistResource>(artist);

      return Ok(artistResource);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ArtistResource>> UpdateArtist(int id, [FromBody] SaveArtistResource saveArtistResource)
    {
      var requestIsInvalid = id == 0 || !ModelState.IsValid;

      if (requestIsInvalid)
        return BadRequest(ModelState); // this needs refining, but for demo it is ok

      var artistToBeUpdated = await _artistService.GetArtistById(id);

      if (artistToBeUpdated == null)
        return NotFound();

      var artist = _mapper.Map<Artist>(saveArtistResource);

      await _artistService.UpdateArtist(artistToBeUpdated, artist);

      var updatedArtist = await _artistService.GetArtistById(id);

      var updatedArtistResource = _mapper.Map<ArtistResource>(updatedArtist);

      return Ok(updatedArtistResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteArtist(int id)
    {
      var artist = await _artistService.GetArtistById(id);

      await _artistService.DeleteArtist(artist);

      return NoContent();
    }
  }
}