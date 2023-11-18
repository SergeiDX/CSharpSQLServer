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
    public class DesarrolladorsController : Controller
    {
        private readonly VideojuegosContext _context;

        public DesarrolladorsController(VideojuegosContext context)
        {
            _context = context;
        }

        // GET: Desarrolladors
        public async Task<IActionResult> Index()
        {
              return _context.Desarrolladors != null ? 
                          View(await _context.Desarrolladors.ToListAsync()) :
                          Problem("Entity set 'VideojuegosContext.Desarrolladors'  is null.");
        }

        // GET: Desarrolladors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Desarrolladors == null)
            {
                return NotFound();
            }

            var desarrollador = await _context.Desarrolladors
                .FirstOrDefaultAsync(m => m.IdDesarrollador == id);
            if (desarrollador == null)
            {
                return NotFound();
            }

            return View(desarrollador);
        }

        // GET: Desarrolladors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Desarrolladors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDesarrollador,NombreDesarrollador,Fundacion,PaisOrigen,SitioWeb")] Desarrollador desarrollador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(desarrollador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(desarrollador);
        }

        // GET: Desarrolladors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Desarrolladors == null)
            {
                return NotFound();
            }

            var desarrollador = await _context.Desarrolladors.FindAsync(id);
            if (desarrollador == null)
            {
                return NotFound();
            }
            return View(desarrollador);
        }

        // POST: Desarrolladors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDesarrollador,NombreDesarrollador,Fundacion,PaisOrigen,SitioWeb")] Desarrollador desarrollador)
        {
            if (id != desarrollador.IdDesarrollador)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(desarrollador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DesarrolladorExists(desarrollador.IdDesarrollador))
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
            return View(desarrollador);
        }

        // GET: Desarrolladors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Desarrolladors == null)
            {
                return NotFound();
            }

            var desarrollador = await _context.Desarrolladors
                .FirstOrDefaultAsync(m => m.IdDesarrollador == id);
            if (desarrollador == null)
            {
                return NotFound();
            }

            return View(desarrollador);
        }

        // POST: Desarrolladors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Desarrolladors == null)
            {
                return Problem("Entity set 'VideojuegosContext.Desarrolladors'  is null.");
            }
            var desarrollador = await _context.Desarrolladors.FindAsync(id);
            if (desarrollador != null)
            {
                _context.Desarrolladors.Remove(desarrollador);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DesarrolladorExists(int id)
        {
          return (_context.Desarrolladors?.Any(e => e.IdDesarrollador == id)).GetValueOrDefault();
        }
    }
}
