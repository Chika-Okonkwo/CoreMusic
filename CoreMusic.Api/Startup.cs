using AutoMapper;
using CoreMusic.Core;
using CoreMusic.Core.Services;
using CoreMusic.Data;
using CoreMusic.Services;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;
using System.Reflection;

namespace CoreMusic.Api
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services
        .AddControllers()
        .AddFluentValidation(opt =>
        {
          opt.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        });

      var conString = Configuration.GetConnectionString("Default");
      services.AddDbContext<CoreMusicDbContext>(options => options.UseSqlServer(conString, x => x.MigrationsAssembly("CoreMusic.Data")));

      services.AddScoped<IUnitOfWork, UnitOfWork>();

      services.AddTransient<IMusicService, MusicService>();
      services.AddTransient<IArtistService, ArtistService>();

      // swagger gen
      services.AddSwaggerGen(options =>
      {
        options.SwaggerDoc("v1", new OpenApiInfo { Title = "Core Music", Version = "v1" });
      });

      services.AddAutoMapper(typeof(Startup));
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseHttpsRedirection();

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });

      // swagger ui
      app.UseSwagger();
      app.UseSwaggerUI(c =>
      {
        c.RoutePrefix = "";
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Music V1");
      });
    }
  }
}
