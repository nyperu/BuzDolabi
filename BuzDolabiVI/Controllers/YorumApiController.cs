using BuzDolabiVI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BuzDolabiVI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YorumApiController : ControllerBase
    {

        private readonly ApplicationDbContext k;

        public YorumApiController(ApplicationDbContext context)
        {
            k = context;
        }
        List<Yorum> Yorumlar = new List<Yorum>();
        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<ActionResult<List<Yorum>>> Get()
        {
            var y = await k.Yorum.ToListAsync();
            if (y is null)
            {
                return NoContent();
            }
            return y;

        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Yorum>> Get(int id)
        {
            var y = await k.Yorum.FirstOrDefaultAsync(x => x.yorumID == id);
            if (y is null)
            {
                return NoContent();
            }
            return y;
        }

        // POST api/<ValuesController>
        [HttpPost]
        public IActionResult Post([FromBody] Yorum y)
        {
            k.Yorum.Add(y);
            k.SaveChanges();
            return Ok();
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Yorum y)
        {
            var y1 = k.Yorum.FirstOrDefault(x => x.yorumID == id);
            if (y1 is null)
            {
                return NotFound();
            }
            y1.yorumAdSoyad = y.yorumAdSoyad;
            y1.yorumTarih = y.yorumTarih;
            y1.yorumIcerik = y.yorumIcerik;
            y1.yorumCinsiyet = y.yorumCinsiyet;
            y1.yorumSosyal = y.yorumSosyal;
            y1.yorumOzluSoz = y.yorumOzluSoz;
          
            k.Update(y1);
            k.SaveChanges();
            return Ok();
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var y1 = k.Yorum.FirstOrDefault(x => x.yorumID == id);
            if (y1 is null)
            {
                return NotFound();
            }
            if (k.Yorum.Any(x => x.yorumID == id))
            {
                return NotFound("Yoruma ait tarif var");
            }
            k.Yorum.Remove(y1);
            k.SaveChanges();
            return Ok();
        }
    }
}
