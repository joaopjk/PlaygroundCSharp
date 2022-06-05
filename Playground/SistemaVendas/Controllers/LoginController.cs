using Microsoft.AspNetCore.Mvc;

namespace SistemaVendas.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
