using BuzDolabiVI.Models;
using BuzDolabiVI.Views.Tarifler;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BuzDolabiVI.Controllers
{
    public class TariflerController : Controller
    {
        private readonly ILogger<TariflerController> _logger;

        public TariflerController(ILogger<TariflerController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult TarifGoster(int id)
        {
            return View("Detayli_Tarif", id);
        }
        public IActionResult TarifEkle()
        {
            return View("TarifEkle");
        }
    }
}