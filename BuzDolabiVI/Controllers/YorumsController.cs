using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BuzDolabiVI.Models;
using System.Globalization;
using System.Data;
using Microsoft.AspNetCore.Authorization;

namespace BuzDolabiVI.Controllers
{
    public class YorumsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public YorumsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Yorums
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Yorum.Include(y => y.Tarif);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Yorums/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Yorum == null)
            {
                return NotFound();
            }

            var yorum = await _context.Yorum
                .Include(y => y.Tarif)
                .FirstOrDefaultAsync(m => m.yorumID == id);
            if (yorum == null)
            {
                return NotFound();
            }

            return View(yorum);
        }

        // GET: Yorums/Create
        public IActionResult Create(int? id)
        {

            ViewData["tarifID"] = new SelectList(_context.Tarif, "tarifID", "tarifID");
            string email = User.Identity.Name;
            ViewData["tarifler"] = _context.Tarif.ToList();
            ViewData["yorumlar"] = _context.Yorum.ToList();
            ViewData["tID"] = id;
            var yorumlar = _context.Yorum.ToList();
            var yorumKontrol = (from m in yorumlar
                        where m.tarifID == id
                        select m).ToList();
            if (email == null)
            {
                var kullanicilar = _context.Users.ToList();
                var kullanici = (from m in kullanicilar
                            select m).ToList();
                string ozluSozz = kullanici[0].ozluSoz.ToString();
                string cinsiyett = kullanici[0].cinsiyet.ToString();
                string sosyalMedyaa = kullanici[0].sosyalMedya.ToString();
                string adi22 = kullanici[0].AdSoyad.ToString();
                string tarihh = DateTime.Now.ToString("MM/dd/yyyy HH:mm", CultureInfo.InvariantCulture);
                ViewData["tarih"] = tarihh;
                ViewData["yorumCinsiyet"] = cinsiyett;
                ViewData["yorumOzluSoz"] = ozluSozz;
                ViewData["yorumSosyalMedya"] = sosyalMedyaa;
                ViewData["yorumAdi"] = adi22;
            }
            else
            {
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
                ViewData["yorumCinsiyet"] = cinsiyet;
                ViewData["yorumOzluSoz"] = ozluSoz;
                ViewData["yorumSosyalMedya"] = sosyalMedya;
                ViewData["yorumAdi"] = adi2;
            }

          
            return View();
        }

        // POST: Yorums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("yorumID,yorumOnay,yorumTarih,yorumIcerik,yorumAdSoyad,yorumOzluSoz,yorumCinsiyet,yorumSosyal,tarifID")] Yorum yorum, int? id)
        {

            ViewData["tarifID"] = new SelectList(_context.Tarif, "tarifID", "tarifID");
            string email = User.Identity.Name;
            ViewData["tarifler"] = _context.Tarif.ToList();
            ViewData["yorumlar"] = _context.Yorum.ToList();
            ViewData["tID"] = id;
            var yorumlar = _context.Yorum.ToList();
            var yorumKontrol = (from m in yorumlar
                                where m.tarifID == id
                                select m).ToList();
            if (email == null)
            {
                var kullanicilar = _context.Users.ToList();
                var kullanici = (from m in kullanicilar
                                 select m).ToList();
                string ozluSozz = kullanici[0].ozluSoz.ToString();
                string cinsiyett = kullanici[0].cinsiyet.ToString();
                string sosyalMedyaa = kullanici[0].sosyalMedya.ToString();
                string adi22 = kullanici[0].AdSoyad.ToString();
                string tarihh = DateTime.Now.ToString("MM/dd/yyyy HH:mm", CultureInfo.InvariantCulture);
                ViewData["tarih"] = tarihh;
                ViewData["yorumCinsiyet"] = cinsiyett;
                ViewData["yorumOzluSoz"] = ozluSozz;
                ViewData["yorumSosyalMedya"] = sosyalMedyaa;
                ViewData["yorumAdi"] = adi22;
            }
            else
            {
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
                ViewData["yorumCinsiyet"] = cinsiyet;
                ViewData["yorumOzluSoz"] = ozluSoz;
                ViewData["yorumSosyalMedya"] = sosyalMedya;
                ViewData["yorumAdi"] = adi2;
            }
            _context.Add(yorum);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Create));

            ViewData["tarifID"] = new SelectList(_context.Tarif, "tarifID", "tarifID", yorum.tarifID);

            return View(yorum);
        }

        // GET: Yorums/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Yorum == null)
            {
                return NotFound();
            }

            var yorum = await _context.Yorum.FindAsync(id);
            if (yorum == null)
            {
                return NotFound();
            }
            ViewData["tarifID"] = new SelectList(_context.Tarif, "tarifID", "tarifID", yorum.tarifID);
            return View(yorum);
        }

        // POST: Yorums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("yorumID,yorumOnay,yorumTarih,yorumIcerik,yorumAdSoyad,yorumOzluSoz,yorumCinsiyet,yorumSosyal,tarifID")] Yorum yorum)
        {
            if (id != yorum.yorumID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(yorum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!YorumExists(yorum.yorumID))
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
            ViewData["tarifID"] = new SelectList(_context.Tarif, "tarifID", "tarifID", yorum.tarifID);
            return View(yorum);
        }

        // GET: Yorums/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Yorum == null)
            {
                return NotFound();
            }

            var yorum = await _context.Yorum
                .Include(y => y.Tarif)
                .FirstOrDefaultAsync(m => m.yorumID == id);
            if (yorum == null)
            {
                return NotFound();
            }

            return View(yorum);
        }

        // POST: Yorums/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Yorum == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Yorum'  is null.");
            }
            var yorum = await _context.Yorum.FindAsync(id);
            if (yorum != null)
            {
                _context.Yorum.Remove(yorum);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool YorumExists(int id)
        {
            return _context.Yorum.Any(e => e.yorumID == id);
        }
    }
}
