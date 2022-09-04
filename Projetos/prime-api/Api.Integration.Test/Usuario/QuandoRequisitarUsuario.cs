using Api.Domain.Dtos.User;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Api.Integration.Test.Usuario
{
  public class QuandoRequisitarUsuario : BaseIntegration
  {
    private string Name { get; set; }
    private string Email { get; set; }

    public override void Dispose()
    {
      throw new System.NotImplementedException();
    }

    [Fact(DisplayName = "É possivel realizar CRUD de usuário")]
    public async Task E_possivel_realizar_CRUD_usuario()
    {
      await AdicionarToken();
      Name = Faker.Name.FullName();
      Email = Faker.Internet.Email();

      var userDto = new UserDtoCreate()
      {
        Name = Name,
        Email = Email
      };

      //Post
      var responseCreate = await PostJsonAsync(userDto, $"{HostApi}users", Client);
      var registroPost = JsonConvert.DeserializeObject<UserDtoCreateResult>(await responseCreate.Content.ReadAsStringAsync());
      Assert.Equal(HttpStatusCode.Created, responseCreate.StatusCode);
      Assert.Equal(Name, registroPost.Name);
      Assert.Equal(Email, registroPost.Email);
      Assert.True(registroPost.Id != default);

      //getAll
      Response = await Client.GetAsync($"{HostApi}users");
      Assert.Equal(HttpStatusCode.OK, Response.StatusCode);
      var listaUsuario = JsonConvert.DeserializeObject<IEnumerable<UserDto>>(await Response.Content.ReadAsStringAsync());
      Assert.NotNull(listaUsuario);
      Assert.True(listaUsuario.Any());
      Assert.Contains(listaUsuario, x => x.Id == registroPost.Id);

      //Put
      var updateUserDto = new UserDtoUpdate()
      {
        Id = registroPost.Id,
        Name = Faker.Name.FullName(),
        Email = Faker.Internet.Email()
      };

      var stringContent = new StringContent(JsonConvert.SerializeObject(updateUserDto), Encoding.UTF8, "application/json");
      Response = await Client.PutAsync($"{HostApi}users", stringContent);
      var registroAtualizado = JsonConvert.DeserializeObject<UserDtoUpdateResult>(await Response.Content.ReadAsStringAsync());
      Assert.Equal(HttpStatusCode.OK, Response.StatusCode);
      Assert.NotEqual(registroAtualizado.Name, Name);
      Assert.NotEqual(registroAtualizado.Email, Email);

      //Get
      Response = await Client.GetAsync($"{HostApi}users/GetWithId/{registroAtualizado.Id}");
      Assert.Equal(HttpStatusCode.OK, Response.StatusCode);
      var getusuario = JsonConvert.DeserializeObject<UserDto>(await Response.Content.ReadAsStringAsync());
      Assert.NotNull(getusuario);

      //Delete
      Response = await Client.DeleteAsync($"{HostApi}users/{registroAtualizado.Id}");
      Assert.Equal(HttpStatusCode.OK, Response.StatusCode);
    }
  }
}
