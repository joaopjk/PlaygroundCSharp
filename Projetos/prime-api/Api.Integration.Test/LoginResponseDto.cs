using Newtonsoft.Json;
using System;

namespace Api.Integration.Test
{
  public class LoginResponseDto
  {
    [JsonProperty("authenticated")]
    public bool Authenticated { get; set; }

    [JsonProperty("createDate")]
    public DateTime CreateDate { get; set; }

    [JsonProperty("expirationDate")]
    public DateTime ExpirationDate { get; set; }

    [JsonProperty("accessToken")]
    public string AccessToken { get; set; }

    [JsonProperty("userName")]
    public string UserName { get; set; }

    [JsonProperty("message")]
    public string Message { get; set; }
  }
}
