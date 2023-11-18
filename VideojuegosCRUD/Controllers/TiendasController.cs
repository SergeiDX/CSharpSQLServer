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
    public class TiendasController : Controller
    {
        private readonly VideojuegosContext _context;

        public TiendasController(VideojuegosContext context)
        {
            _context = context;
        }

        // GET: Tiendas
        public async Task<IActionResult> Index()
        {
            var videojuegosContext = _context.Tiendas.Include(t => t.IdVentaNavigation).Include(t => t.IdVideojuegoNavigation);
            return View(await videojuegosContext.ToListAsync());
        }

        // GET: Tiendas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Tiendas == null)
            {
                return NotFound();
            }

            var tienda = await _context.Tiendas
                .Include(t => t.IdVentaNavigation)
                .Include(t => t.IdVideojuegoNavigation)
                .FirstOrDefaultAsync(m => m.IdTienda == id);
            if (tienda == null)
            {
                return NotFound();
            }

            return View(tienda);
        }

        // GET: Tiendas/Create
        public IActionResult Create()
        {
            ViewData["IdVenta"] = new SelectList(_context.Ventas, "IdVenta", "IdVenta");
            ViewData["IdVideojuego"] = new SelectList(_context.Videojuegos, "IdVideojuego", "IdVideojuego");
            return View();
        }

        // POST: Tiendas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTienda,NombreTienda,IdVideojuego,IdVenta")] Tienda tienda)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tienda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdVenta"] = new SelectList(_context.Ventas, "IdVenta", "IdVenta", tienda.IdVenta);
            ViewData["IdVideojuego"] = new SelectList(_context.Videojuegos, "IdVideojuego", "IdVideojuego", tienda.IdVideojuego);
            return View(tienda);
        }

        // GET: Tiendas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Tiendas == null)
            {
                return NotFound();
            }

            var tienda = await _context.Tiendas.FindAsync(id);
            if (tienda == null)
            {
                return NotFound();
            }
            ViewData["IdVenta"] = new SelectList(_context.Ventas, "IdVenta", "IdVenta", tienda.IdVenta);
            ViewData["IdVideojuego"] = new SelectList(_context.Videojuegos, "IdVideojuego", "IdVideojuego", tienda.IdVideojuego);
            return View(tienda);
        }

        // POST: Tiendas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTienda,NombreTienda,IdVideojuego,IdVenta")] Tienda tienda)
        {
            if (id != tienda.IdTienda)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tienda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TiendaExists(tienda.IdTienda))
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
            ViewData["IdVenta"] = new SelectList(_context.Ventas, "IdVenta", "IdVenta", tienda.IdVenta);
            ViewData["IdVideojuego"] = new SelectList(_context.Videojuegos, "IdVideojuego", "IdVideojuego", tienda.IdVideojuego);
            return View(tienda);
        }

        // GET: Tiendas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Tiendas == null)
            {
                return NotFound();
            }

            var tienda = await _context.Tiendas
                .Include(t => t.IdVentaNavigation)
                .Include(t => t.IdVideojuegoNavigation)
                .FirstOrDefaultAsync(m => m.IdTienda == id);
            if (tienda == null)
            {
                return NotFound();
            }

            return View(tienda);
        }

        // POST: Tiendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Tiendas == null)
            {
                return Problem("Entity set 'VideojuegosContext.Tiendas'  is null.");
            }
            var tienda = await _context.Tiendas.FindAsync(id);
            if (tienda != null)
            {
                _context.Tiendas.Remove(tienda);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TiendaExists(int id)
        {
          return (_context.Tiendas?.Any(e => e.IdTienda == id)).GetValueOrDefault();
        }
    }
}
