using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BuzDolabiVI.Models;
using BuzDolabiVI.Data;

namespace BuzDolabiVI.Controllers
{
    public class YorumController : Controller
    {
        private readonly ApplicationDbContext _context;

        public YorumController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Yorum
        public async Task<IActionResult> Index()
        {
              return View(await _context.Yorum.ToListAsync());
        }

        // GET: Yorum/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Yorum == null)
            {
                return NotFound();
            }

            var yorum = await _context.Yorum
                .FirstOrDefaultAsync(m => m.yorumID == id);
            if (yorum == null)
            {
                return NotFound();
            }

            return View(yorum);
        }

        // GET: Yorum/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Yorum/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("yorumID,userID,kullaniciAdi,tarifAdi,kategoriID,onay,tarifID,tarih,icerik")] Yorum yorum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(yorum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(yorum);
        }

        // GET: Yorum/Edit/5
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
            return View(yorum);
        }

        // POST: Yorum/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("yorumID,userID,kullaniciAdi,tarifAdi,kategoriID,onay,tarifID,tarih,icerik")] Yorum yorum)
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
            return View(yorum);
        }

        // GET: Yorum/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Yorum == null)
            {
                return NotFound();
            }

            var yorum = await _context.Yorum
                .FirstOrDefaultAsync(m => m.yorumID == id);
            if (yorum == null)
            {
                return NotFound();
            }

            return View(yorum);
        }

        // POST: Yorum/Delete/5
        [HttpPost, ActionName("Delete")]
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
