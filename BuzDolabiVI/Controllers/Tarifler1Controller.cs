using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BuzDolabiVI.Data;
using BuzDolabiVI.Models;
using Microsoft.AspNetCore.Authorization;

namespace BuzDolabiVI.Controllers
{
   
    public class Tarifler1Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public Tarifler1Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Tarifler1
        public async Task<IActionResult> Index()
        {
              return View(await _context.Tarifler1.ToListAsync());
        }

        // GET: Tarifler1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Tarifler1 == null)
            {
                return NotFound();
            }

            var tarifler1 = await _context.Tarifler1
                .FirstOrDefaultAsync(m => m.tarifID == id);
            if (tarifler1 == null)
            {
                return NotFound();
            }

            return View(tarifler1);
        }

        // GET: Tarifler1/Create
        
        public IActionResult Create()
        {
            return View(User);
        }

        // POST: Tarifler1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Create([Bind("tarifID,tarifAd,tarifFoto,tarifMalzemeler,tarifNasilYapilir,tarifTarih,goruntulenme,tarifGirisYazisi,kacKalori,besinDegeriLink,kacKisilik,hazirlanmaSuresi,pisirmeSuresi,onay,yazarAd,yazarOzluSoz,yazarCinsiyet,yazarSosyal")] Tarifler1 tarifler1)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tarifler1);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tarifler1);
        }

        // GET: Tarifler1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Tarifler1 == null)
            {
                return NotFound();
            }

            var tarifler1 = await _context.Tarifler1.FindAsync(id);
            if (tarifler1 == null)
            {
                return NotFound();
            }
            return View(tarifler1);
        }

        // POST: Tarifler1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("tarifID,tarifAd,tarifFoto,tarifMalzemeler,tarifNasilYapilir,tarifTarih,goruntulenme,tarifGirisYazisi,kacKalori,besinDegeriLink,kacKisilik,hazirlanmaSuresi,pisirmeSuresi,onay,yazarAd,yazarOzluSoz,yazarCinsiyet,yazarSosyal")] Tarifler1 tarifler1)
        {
            if (id != tarifler1.tarifID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tarifler1);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Tarifler1Exists(tarifler1.tarifID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tarifler1);
        }

        // GET: Tarifler1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Tarifler1 == null)
            {
                return NotFound();
            }

            var tarifler1 = await _context.Tarifler1
                .FirstOrDefaultAsync(m => m.tarifID == id);
            if (tarifler1 == null)
            {
                return NotFound();
            }

            return View(tarifler1);
        }

        // POST: Tarifler1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Tarifler1 == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Tarifler1'  is null.");
            }
            var tarifler1 = await _context.Tarifler1.FindAsync(id);
            if (tarifler1 != null)
            {
                _context.Tarifler1.Remove(tarifler1);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Tarifler1Exists(int id)
        {
          return _context.Tarifler1.Any(e => e.tarifID == id);
        }
    }
}
