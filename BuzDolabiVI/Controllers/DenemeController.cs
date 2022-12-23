using Microsoft.AspNetCore.Mvc;

namespace BuzDolabi.Controllers
{
    public class DenemeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
