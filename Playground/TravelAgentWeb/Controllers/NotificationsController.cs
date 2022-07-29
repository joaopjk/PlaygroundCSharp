using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TravelAgentWeb.Data;
using TravelAgentWeb.Dtos;

namespace TravelAgentWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly TravelAgentDbContext _context;

        public NotificationsController(TravelAgentDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public ActionResult FlightChanged(FlightDetailUpdateDto request)
        {
            var secretModel = _context.SubscriptionSecrets.FirstOrDefault(
                x => x.Publisher == request.Publisher && x.Secret == request.Secret);
            if (secretModel == null)
                return Ok(); //Ignore Webhook
            return Ok();
        }
    }
}
