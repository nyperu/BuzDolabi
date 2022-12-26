using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BuzdolabiProject.Models;
using System.Globalization;
using BuzdolabiProject.Models;

namespace BuzdolabiProject.Controllers
{
    public class TarifsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TarifsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Tarifs
        public async Task<IActionResult> admin()
        {
            return View(await _context.Tarif.ToListAsync());
        }
        public async Task<IActionResult> adminDetails(int? id)
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
        public async Task<IActionResult> adminDuzenle(int? id)
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
        public async Task<IActionResult> adminDuzenle(int id, [Bind("tarifID,tarifAd,tarifOnay,tarifFoto,tarifMalzemeler,tarifNasilYapilir,tarifTarih,goruntulenme,tarifGirisYazisi,kacKalori,besinDegeriLink,kacKisilik,hazirlanmaSuresi,pisirmeSuresi,kategori,ozluSoz,adSoyad,sosyalMedya,cinsiyet")] Tarif tarif)
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
        public async Task<IActionResult> adminOnay(int? id)
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

            tarif.tarifOnay = "onay";
            _context.Update(tarif);
            await _context.SaveChangesAsync();
            return View(tarif);
        }

        public async Task<IActionResult> Index()
        {
            ViewData["yorumlar"] = _context.Yorum.ToList();
            return View(await _context.Tarif.ToListAsync());
        }
        public async Task<IActionResult> corba()
        {
            ViewData["yorumlar"] = _context.Yorum.ToList();
            return View(await _context.Tarif.ToListAsync());
        }
        public async Task<IActionResult> anaYemek()
        {
            ViewData["yorumlar"] = _context.Yorum.ToList();
            return View(await _context.Tarif.ToListAsync());
        }

        public async Task<IActionResult> tatli()
        {
            ViewData["yorumlar"] = _context.Yorum.ToList();
            return View(await _context.Tarif.ToListAsync());
        }
        public async Task<IActionResult> icecek()
        {
            ViewData["yorumlar"] = _context.Yorum.ToList();
            return View(await _context.Tarif.ToListAsync());
        }



        // GET: Tarifs/Details/5
        public async Task<IActionResult> Details(int? id)
        {

            if (id == null || _context.Tarif == null)
            {
                return NotFound();
            }
            var yorum = _context.Yorum.ToList();
            var yorumlar = (from m in yorum
                            where m.tarifID == id
                            select m).ToList();
            ViewData["yorumlar"] = yorumlar;
            var tarif = await _context.Tarif
                .FirstOrDefaultAsync(m => m.tarifID == id);
            if (tarif == null)
            {
                return NotFound();
            }

            tarif.goruntulenme++;
            _context.Update(tarif);
            await _context.SaveChangesAsync();
            return View(tarif);
        }

        // GET: Tarifs/Create
        public IActionResult Create()
        {
            string email = User.Identity.Name;
            var users = _context.Users.ToList();
            var kisi = (from m in users
                        where m.Email == email
                        select m).ToList();
            string ozluSoz = kisi[0].ozluSoz.ToString();
            string cinsiyet = kisi[0].cinsiyet.ToString();
            string sosyalMedya = kisi[0].sosyalMedya.ToString();
            string adi2 = kisi[0].AdSoyad.ToString();

            string tarih = DateTime.Now.ToString("MM/dd/yyyy HH:mm", CultureInfo.InvariantCulture);
            ViewData["tarih"] = tarih;
            ViewData["tarifCinsiyet"] = cinsiyet;
            ViewData["tarifOzluSoz"] = ozluSoz;
            ViewData["tarifSosyalMedya"] = sosyalMedya;
            ViewData["tarifAdi"] = adi2;
            return View();
        }

        // POST: Tarifs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("tarifID,tarifAd,tarifOnay,tarifFoto,tarifMalzemeler,tarifNasilYapilir,tarifTarih,goruntulenme,tarifGirisYazisi,kacKalori,besinDegeriLink,kacKisilik,hazirlanmaSuresi,pisirmeSuresi,kategori,ozluSoz,adSoyad,sosyalMedya,cinsiyet")] Tarif tarif)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tarif);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tarif);
        }

        // GET: Tarifs/Edit/5
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

        // POST: Tarifs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("tarifID,tarifAd,tarifOnay,tarifFoto,tarifMalzemeler,tarifNasilYapilir,tarifTarih,goruntulenme,tarifGirisYazisi,kacKalori,besinDegeriLink,kacKisilik,hazirlanmaSuresi,pisirmeSuresi,kategori,ozluSoz,adSoyad,sosyalMedya,cinsiyet")] Tarif tarif)
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

        // GET: Tarifs/Delete/5
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

        // POST: Tarifs/Delete/5
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
