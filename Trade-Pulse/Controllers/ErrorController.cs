using Microsoft.AspNetCore.Mvc;

namespace Trade_Pulse.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
