using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VideojuegosCRUD.Models;

namespace VideojuegosCRUD.Controllers
{
    public class VideojuegoesController : Controller
    {
        private readonly VideojuegosContext _context;

        public VideojuegoesController(VideojuegosContext context)
        {
            _context = context;
        }

        // GET: Videojuegoes
        public async Task<IActionResult> Index()
        {
            var videojuegosContext = _context.Videojuegos.Include(v => v.IdDesarrolladorNavigation);
            return View(await videojuegosContext.ToListAsync());
        }

        // GET: Videojuegoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Videojuegos == null)
            {
                return NotFound();
            }

            var videojuego = await _context.Videojuegos
                .Include(v => v.IdDesarrolladorNavigation)
                .FirstOrDefaultAsync(m => m.IdVideojuego == id);
            if (videojuego == null)
            {
                return NotFound();
            }

            return View(videojuego);
        }

        // GET: Videojuegoes/Create
        public IActionResult Create()
        {
            ViewData["IdDesarrollador"] = new SelectList(_context.Desarrolladors, "IdDesarrollador", "IdDesarrollador");
            return View();
        }

        // POST: Videojuegoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdVideojuego,TituloVideojuego,Lanzamiento,IdDesarrollador")] Videojuego videojuego)
        {
            if (ModelState.IsValid)
            {
                _context.Add(videojuego);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdDesarrollador"] = new SelectList(_context.Desarrolladors, "IdDesarrollador", "IdDesarrollador", videojuego.IdDesarrollador);
            return View(videojuego);
        }

        // GET: Videojuegoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Videojuegos == null)
            {
                return NotFound();
            }

            var videojuego = await _context.Videojuegos.FindAsync(id);
            if (videojuego == null)
            {
                return NotFound();
            }
            ViewData["IdDesarrollador"] = new SelectList(_context.Desarrolladors, "IdDesarrollador", "IdDesarrollador", videojuego.IdDesarrollador);
            return View(videojuego);
        }

        // POST: Videojuegoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdVideojuego,TituloVideojuego,Lanzamiento,IdDesarrollador")] Videojuego videojuego)
        {
            if (id != videojuego.IdVideojuego)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(videojuego);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VideojuegoExists(videojuego.IdVideojuego))
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
            ViewData["IdDesarrollador"] = new SelectList(_context.Desarrolladors, "IdDesarrollador", "IdDesarrollador", videojuego.IdDesarrollador);
            return View(videojuego);
        }

        // GET: Videojuegoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Videojuegos == null)
            {
                return NotFound();
            }

            var videojuego = await _context.Videojuegos
                .Include(v => v.IdDesarrolladorNavigation)
                .FirstOrDefaultAsync(m => m.IdVideojuego == id);
            if (videojuego == null)
            {
                return NotFound();
            }

            return View(videojuego);
        }

        // POST: Videojuegoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Videojuegos == null)
            {
                return Problem("Entity set 'VideojuegosContext.Videojuegos'  is null.");
            }
            var videojuego = await _context.Videojuegos.FindAsync(id);
            if (videojuego != null)
            {
                _context.Videojuegos.Remove(videojuego);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VideojuegoExists(int id)
        {
          return (_context.Videojuegos?.Any(e => e.IdVideojuego == id)).GetValueOrDefault();
        }
    }
}
