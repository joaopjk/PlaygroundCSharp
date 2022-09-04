using System.Threading.Tasks;
using Xunit;

namespace Api.Integration.Test
{
  public class LoginTest : BaseIntegration
  {
    public override void Dispose()
    {
      throw new System.NotImplementedException();
    }

    [Fact]
    public async Task TesteToken()
    {
      await AdicionarToken();
    }
  }
}
