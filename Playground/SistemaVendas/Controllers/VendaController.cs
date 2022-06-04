using Microsoft.AspNetCore.Mvc;

namespace SistemaVendas.Controllers
{
    public class VendaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
