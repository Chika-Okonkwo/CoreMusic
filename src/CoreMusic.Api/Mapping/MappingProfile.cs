using AutoMapper;
using CoreMusic.Api.Resources;
using CoreMusic.Core.Models;

namespace CoreMusic.Api.Mapping
{
  public class MappingProfile : Profile
  {
    public MappingProfile()
    {
      // Domain to Resource
      CreateMap<Music, MusicResource>();
      CreateMap<Artist, ArtistResource>();

      // Resource to Domain
      CreateMap<MusicResource, Music>();
      CreateMap<ArtistResource, Artist>();
      CreateMap<SaveMusicResource, Music>();
      CreateMap<SaveArtistResource, Artist>();
    }
  }
}