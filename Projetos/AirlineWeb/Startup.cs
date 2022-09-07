using AirlineWeb.Data;
using AirlineWeb.MessageBus;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;

namespace AirlineWeb
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public static void ConfigureServices(IServiceCollection services)
    {
      services.AddControllers();
      services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "AirlineWeb", Version = "v1" }));
      services.AddDbContext<AirlineDbContext>(x =>
          x.UseSqlServer("Server=127.0.0.1,1433;Database=Webhooks;user id=SA;Password=Root@123root"));
      services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
      services.AddSingleton<IMessageBusClient, MessageBusClient>();
    }

    public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AirlineWeb v1"));
      }

      app.UseHttpsRedirection();
      app.UseRouting();
      app.UseAuthorization();
      app.UseEndpoints(endpoints => endpoints.MapControllers());
    }
  }
}
