using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CoreMusic.Core.Models
{
  public partial class Artist
  {
    public Artist()
    {
      Music = new Collection<Music>();
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public virtual ICollection<Music> Music { get; set; }
  }
}
