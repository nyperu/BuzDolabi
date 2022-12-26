using Microsoft.AspNetCore.Mvc;

namespace BuzdolabiProject.Controllers
{
    public class CorbaController : Controller
    {
        public IActionResult Index()
        {
            //return View("../Icecek/Index");
            return View();
        }
    }
}
