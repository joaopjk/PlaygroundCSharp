using Api.CrossCutting.DependencyInjection;
using Api.Data.Context;
using Api.Domain.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using prime_api;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Api.Integration.Test
{
  public abstract class BaseIntegration : IDisposable
  {
    public ContextApi Context { get; }
    public HttpClient Client { get; }
    public IMapper Mapper { get; set; }
    public string HostApi { get; set; }
    public HttpResponseMessage Response { get; set; }
    protected BaseIntegration()
    {
      HostApi = "http://localhost:5050/api/";
      var builder = new WebHostBuilder()
          .UseEnvironment("Testing")
          .UseStartup<Startup>();
      var server = new TestServer(builder);
      Context = server.Host.Services.GetService(typeof(ContextApi)) as ContextApi;
      Context.Database.Migrate();
      Mapper = ConfigureMapping.MapperConfigure().CreateMapper();
      Client = server.CreateClient();
    }

    public abstract void Dispose();

    public async Task AdicionarToken()
    {
      var loginDto = new LoginDto()
      {
        Email = "joaopjk48@gmail.com"
      };

      var resultLogin = await PostJsonAsync(loginDto, $"{HostApi}login", Client);
      var loginObject = JsonConvert.DeserializeObject<LoginResponseDto>(await resultLogin.Content.ReadAsStringAsync());

      Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", loginObject.AccessToken);
    }

    public static async Task<HttpResponseMessage> PostJsonAsync(object dataclass, string url, HttpClient client)
    {
      return await client.PostAsync(url, new StringContent(JsonConvert.SerializeObject(dataclass), Encoding.UTF8, "application/json"));
    }
  }
}
