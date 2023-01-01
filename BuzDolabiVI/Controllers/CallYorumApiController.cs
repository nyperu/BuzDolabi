using BuzDolabiVI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BuzDolabiVI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CallYorumApiController : Controller
    {
        public async Task<IActionResult> Index()
        { 
            List<Yorum> Yorumlar = new List<Yorum>();
            var hhtc = new HttpClient();
            var response = await hhtc.GetAsync("https://localhost:7284/api/YorumApi");
            string resString = await response.Content.ReadAsStringAsync();
            Yorumlar = JsonConvert.DeserializeObject<List<Yorum>>(resString);
            return View(Yorumlar);
        }
        
    }
}
