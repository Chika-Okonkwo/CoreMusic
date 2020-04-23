using System;
using System.Threading.Tasks;
using CoreMusic.Core.Repositories;

namespace CoreMusic.Core
{
  public interface IUnitOfWork : IDisposable
  {
    IMusicRepository Music { get; }
    IArtistRepository Artist { get; }
    Task<int> CommitAsync();
  }
}