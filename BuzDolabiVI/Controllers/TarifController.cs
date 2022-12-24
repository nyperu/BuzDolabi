using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BuzDolabiVI.Data;
using BuzDolabiVI.Models;

namespace BuzDolabiVI.Controllers
{
    public class TarifController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TarifController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Tarif
        public async Task<IActionResult> Index()
        {
              return View(await _context.Tarif.ToListAsync());
        }

        // GET: Tarif/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Tarif == null)
            {
                return NotFound();
            }

            var tarif = await _context.Tarif
                .FirstOrDefaultAsync(m => m.tarifID == id);
            if (tarif == null)
            {
                return NotFound();
            }

            return View(tarif);
        }

        // GET: Tarif/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tarif/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("tarifID,userID,tarifAd,tarifMalzemeler,tarifNasilYapilir,tarifTarih,goruntulenme,tarifGirisYazisi,kacKalori,besinDegeriLink,kacKisilik,hazirlanmaSuresi,pisirmeSuresi,yazarAd,yazarOzluSoz,yazarCinsiyet,yazarSosyal")] Tarif tarif)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tarif);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tarif);
        }

        // GET: Tarif/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Tarif == null)
            {
                return NotFound();
            }

            var tarif = await _context.Tarif.FindAsync(id);
            if (tarif == null)
            {
                return NotFound();
            }
            return View(tarif);
        }

        // POST: Tarif/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("tarifID,userID,tarifAd,tarifMalzemeler,tarifNasilYapilir,tarifTarih,goruntulenme,tarifGirisYazisi,kacKalori,besinDegeriLink,kacKisilik,hazirlanmaSuresi,pisirmeSuresi,yazarAd,yazarOzluSoz,yazarCinsiyet,yazarSosyal")] Tarif tarif)
        {
            if (id != tarif.tarifID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tarif);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TarifExists(tarif.tarifID))
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
            return View(tarif);
        }

        // GET: Tarif/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Tarif == null)
            {
                return NotFound();
            }

            var tarif = await _context.Tarif
                .FirstOrDefaultAsync(m => m.tarifID == id);
            if (tarif == null)
            {
                return NotFound();
            }

            return View(tarif);
        }

        // POST: Tarif/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Tarif == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Tarif'  is null.");
            }
            var tarif = await _context.Tarif.FindAsync(id);
            if (tarif != null)
            {
                _context.Tarif.Remove(tarif);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TarifExists(int id)
        {
          return _context.Tarif.Any(e => e.tarifID == id);
        }
    }
}
