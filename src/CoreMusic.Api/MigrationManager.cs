using System;
using CoreMusic.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CoreMusic.Api
{
  public static class MigrationManager
  {
    public static IHost MigrateDatabase(this IHost host)
    {
      using (var scope = host.Services.CreateScope())
      {
        using (var appContext = scope.ServiceProvider.GetRequiredService<CoreMusicDbContext>())
        {
          try
          {
            appContext.Database.Migrate();
          }
          catch (Exception e)
          {
            //log errors
            throw e;
          }
        }
      }

      return host;
    }
  }
}