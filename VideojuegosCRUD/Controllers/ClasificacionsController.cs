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
    public class ClasificacionsController : Controller
    {
        private readonly VideojuegosContext _context;

        public ClasificacionsController(VideojuegosContext context)
        {
            _context = context;
        }

        // GET: Clasificacions
        public async Task<IActionResult> Index()
        {
              return _context.Clasificacions != null ? 
                          View(await _context.Clasificacions.ToListAsync()) :
                          Problem("Entity set 'VideojuegosContext.Clasificacions'  is null.");
        }

        // GET: Clasificacions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Clasificacions == null)
            {
                return NotFound();
            }

            var clasificacion = await _context.Clasificacions
                .FirstOrDefaultAsync(m => m.IdClasificacion == id);
            if (clasificacion == null)
            {
                return NotFound();
            }

            return View(clasificacion);
        }

        // GET: Clasificacions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clasificacions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdClasificacion,Clasificacion1,TipoClasificacion")] Clasificacion clasificacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clasificacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clasificacion);
        }

        // GET: Clasificacions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Clasificacions == null)
            {
                return NotFound();
            }

            var clasificacion = await _context.Clasificacions.FindAsync(id);
            if (clasificacion == null)
            {
                return NotFound();
            }
            return View(clasificacion);
        }

        // POST: Clasificacions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdClasificacion,Clasificacion1,TipoClasificacion")] Clasificacion clasificacion)
        {
            if (id != clasificacion.IdClasificacion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clasificacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClasificacionExists(clasificacion.IdClasificacion))
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
            return View(clasificacion);
        }

        // GET: Clasificacions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Clasificacions == null)
            {
                return NotFound();
            }

            var clasificacion = await _context.Clasificacions
                .FirstOrDefaultAsync(m => m.IdClasificacion == id);
            if (clasificacion == null)
            {
                return NotFound();
            }

            return View(clasificacion);
        }

        // POST: Clasificacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Clasificacions == null)
            {
                return Problem("Entity set 'VideojuegosContext.Clasificacions'  is null.");
            }
            var clasificacion = await _context.Clasificacions.FindAsync(id);
            if (clasificacion != null)
            {
                _context.Clasificacions.Remove(clasificacion);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClasificacionExists(int id)
        {
          return (_context.Clasificacions?.Any(e => e.IdClasificacion == id)).GetValueOrDefault();
        }
    }
}
