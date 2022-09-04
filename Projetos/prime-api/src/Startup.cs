using Api.CrossCutting.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;

namespace prime_api
{
  public class Startup
  {
    public Startup(IConfiguration configuration, IWebHostEnvironment environment)
    {
      Configuration = configuration;
      Environment = environment;
    }

    public IConfiguration Configuration { get; }
    public IWebHostEnvironment Environment { get; }

    public void ConfigureServices(IServiceCollection services)
    {
      if (Environment.IsEnvironment("Testing"))
      {
        System.Environment.SetEnvironmentVariable("SQL_SERVER", "Server=127.0.0.1,1433;Database=PrimeAPI;user id=SA;Password=Root@123root");
        System.Environment.SetEnvironmentVariable("Audience", "ExemploAudience");
        System.Environment.SetEnvironmentVariable("Issuer", "ExemploIssuer");
        System.Environment.SetEnvironmentVariable("Seconds", "12000");
      }

      services.AddControllers();
      services.ConfigureContextInjection();
      services.ConfigureDependecyInjection();
      services.ConfigureDependecyRepository();
      services.ConfigureJWTInjection();
      services.ConfigureMappingInjection();

      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "prime_api", Version = "v1" });
        var jwtSecurityScheme = new OpenApiSecurityScheme
        {
          Scheme = "bearer",
          BearerFormat = "JWT",
          Name = "JWT Authentication",
          In = ParameterLocation.Header,
          Type = SecuritySchemeType.Http,
          Description = "Put **_ONLY_** your JWT Bearer token on textbox below!",

          Reference = new OpenApiReference
          {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
          }
        };
        c.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);
        c.AddSecurityRequirement(new OpenApiSecurityRequirement
          {
                    { jwtSecurityScheme, Array.Empty<string>() }
          });
      });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "prime_api v1"));
      }

      app.UseHttpsRedirection();

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints => endpoints.MapControllers());
    }
  }
}
