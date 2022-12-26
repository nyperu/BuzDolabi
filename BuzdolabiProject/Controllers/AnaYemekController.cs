using Microsoft.AspNetCore.Mvc;

namespace BuzdolabiProject.Controllers
{
    public class AnaYemekController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
