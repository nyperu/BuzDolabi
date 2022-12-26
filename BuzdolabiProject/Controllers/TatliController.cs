using Microsoft.AspNetCore.Mvc;

namespace BuzdolabiProject.Controllers
{
    public class TatliController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
