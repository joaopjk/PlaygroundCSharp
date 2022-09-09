using CQRS.Core.Infrastructe;
using Microsoft.AspNetCore.Mvc;
using Post.Cmd.Api.Commands;
using Post.Cmd.Api.DTOs;
using Post.Common.DTOS;

namespace Post.Cmd.Api.Controllers
{
  [ApiController]
  [Route("api/v1/[controller]")]
  public class NewPostController : ControllerBase
  {
    private readonly ILogger<NewPostController> _logger;
    private readonly ICommandDispatcher _dispatcher;

    public NewPostController(ILogger<NewPostController> logger, ICommandDispatcher dispatcher)
    {
      _logger = logger;
      _dispatcher = dispatcher;
    }

    [HttpPost]
    public async Task<ActionResult> NewPostAsync(NewPostCommand command)
    {
      try
      {
        command.Id = Guid.NewGuid();

        await _dispatcher.SendAsync(command);

        return StatusCode(StatusCodes.Status201Created, new NewPostResponse
        {
          Message = "New post creation request completed successfully"
        });
      }
      catch (Exception ex)
      {
        _logger.Log(LogLevel.Warning, ex, "Client made a bad request");
        return BadRequest(new BaseResponse
        {
          Message = ex.Message
        });
      }
    }
  }
}