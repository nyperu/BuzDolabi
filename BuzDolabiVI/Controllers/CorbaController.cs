using Microsoft.AspNetCore.Mvc;

namespace BuzDolabiVI.Controllers
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
