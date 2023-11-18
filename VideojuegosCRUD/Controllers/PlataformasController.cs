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
    public class PlataformasController : Controller
    {
        private readonly VideojuegosContext _context;

        public PlataformasController(VideojuegosContext context)
        {
            _context = context;
        }

        // GET: Plataformas
        public async Task<IActionResult> Index()
        {
            var videojuegosContext = _context.Plataformas.Include(p => p.IdUsuarioNavigation).Include(p => p.IdVideojuegoNavigation);
            return View(await videojuegosContext.ToListAsync());
        }

        // GET: Plataformas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Plataformas == null)
            {
                return NotFound();
            }

            var plataforma = await _context.Plataformas
                .Include(p => p.IdUsuarioNavigation)
                .Include(p => p.IdVideojuegoNavigation)
                .FirstOrDefaultAsync(m => m.IdPlataforma == id);
            if (plataforma == null)
            {
                return NotFound();
            }

            return View(plataforma);
        }

        // GET: Plataformas/Create
        public IActionResult Create()
        {
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario");
            ViewData["IdVideojuego"] = new SelectList(_context.Videojuegos, "IdVideojuego", "IdVideojuego");
            return View();
        }

        // POST: Plataformas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPlataforma,NombrePlataforma,Fabricante,IdVideojuego,IdUsuario")] Plataforma plataforma)
        {
            if (ModelState.IsValid)
            {
                _context.Add(plataforma);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", plataforma.IdUsuario);
            ViewData["IdVideojuego"] = new SelectList(_context.Videojuegos, "IdVideojuego", "IdVideojuego", plataforma.IdVideojuego);
            return View(plataforma);
        }

        // GET: Plataformas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Plataformas == null)
            {
                return NotFound();
            }

            var plataforma = await _context.Plataformas.FindAsync(id);
            if (plataforma == null)
            {
                return NotFound();
            }
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", plataforma.IdUsuario);
            ViewData["IdVideojuego"] = new SelectList(_context.Videojuegos, "IdVideojuego", "IdVideojuego", plataforma.IdVideojuego);
            return View(plataforma);
        }

        // POST: Plataformas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPlataforma,NombrePlataforma,Fabricante,IdVideojuego,IdUsuario")] Plataforma plataforma)
        {
            if (id != plataforma.IdPlataforma)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(plataforma);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlataformaExists(plataforma.IdPlataforma))
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
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "IdUsuario", "IdUsuario", plataforma.IdUsuario);
            ViewData["IdVideojuego"] = new SelectList(_context.Videojuegos, "IdVideojuego", "IdVideojuego", plataforma.IdVideojuego);
            return View(plataforma);
        }

        // GET: Plataformas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Plataformas == null)
            {
                return NotFound();
            }

            var plataforma = await _context.Plataformas
                .Include(p => p.IdUsuarioNavigation)
                .Include(p => p.IdVideojuegoNavigation)
                .FirstOrDefaultAsync(m => m.IdPlataforma == id);
            if (plataforma == null)
            {
                return NotFound();
            }

            return View(plataforma);
        }

        // POST: Plataformas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Plataformas == null)
            {
                return Problem("Entity set 'VideojuegosContext.Plataformas'  is null.");
            }
            var plataforma = await _context.Plataformas.FindAsync(id);
            if (plataforma != null)
            {
                _context.Plataformas.Remove(plataforma);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlataformaExists(int id)
        {
          return (_context.Plataformas?.Any(e => e.IdPlataforma == id)).GetValueOrDefault();
        }
    }
}
