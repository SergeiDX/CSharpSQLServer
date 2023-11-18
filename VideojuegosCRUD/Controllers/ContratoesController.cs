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
    public class ContratoesController : Controller
    {
        private readonly VideojuegosContext _context;

        public ContratoesController(VideojuegosContext context)
        {
            _context = context;
        }

        // GET: Contratoes
        public async Task<IActionResult> Index()
        {
            var videojuegosContext = _context.Contratos.Include(c => c.IdDesarrolladorNavigation).Include(c => c.IdEmpresaNavigation);
            return View(await videojuegosContext.ToListAsync());
        }

        // GET: Contratoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Contratos == null)
            {
                return NotFound();
            }

            var contrato = await _context.Contratos
                .Include(c => c.IdDesarrolladorNavigation)
                .Include(c => c.IdEmpresaNavigation)
                .FirstOrDefaultAsync(m => m.IdContrato == id);
            if (contrato == null)
            {
                return NotFound();
            }

            return View(contrato);
        }

        // GET: Contratoes/Create
        public IActionResult Create()
        {
            ViewData["IdDesarrollador"] = new SelectList(_context.Desarrolladors, "IdDesarrollador", "IdDesarrollador");
            ViewData["IdEmpresa"] = new SelectList(_context.Empresas, "IdEmpresa", "IdEmpresa");
            return View();
        }

        // POST: Contratoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdContrato,DescripcionContrato,FechaInicio,FechaLimite,IdDesarrollador,IdEmpresa")] Contrato contrato)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contrato);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdDesarrollador"] = new SelectList(_context.Desarrolladors, "IdDesarrollador", "IdDesarrollador", contrato.IdDesarrollador);
            ViewData["IdEmpresa"] = new SelectList(_context.Empresas, "IdEmpresa", "IdEmpresa", contrato.IdEmpresa);
            return View(contrato);
        }

        // GET: Contratoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Contratos == null)
            {
                return NotFound();
            }

            var contrato = await _context.Contratos.FindAsync(id);
            if (contrato == null)
            {
                return NotFound();
            }
            ViewData["IdDesarrollador"] = new SelectList(_context.Desarrolladors, "IdDesarrollador", "IdDesarrollador", contrato.IdDesarrollador);
            ViewData["IdEmpresa"] = new SelectList(_context.Empresas, "IdEmpresa", "IdEmpresa", contrato.IdEmpresa);
            return View(contrato);
        }

        // POST: Contratoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdContrato,DescripcionContrato,FechaInicio,FechaLimite,IdDesarrollador,IdEmpresa")] Contrato contrato)
        {
            if (id != contrato.IdContrato)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contrato);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContratoExists(contrato.IdContrato))
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
            ViewData["IdDesarrollador"] = new SelectList(_context.Desarrolladors, "IdDesarrollador", "IdDesarrollador", contrato.IdDesarrollador);
            ViewData["IdEmpresa"] = new SelectList(_context.Empresas, "IdEmpresa", "IdEmpresa", contrato.IdEmpresa);
            return View(contrato);
        }

        // GET: Contratoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Contratos == null)
            {
                return NotFound();
            }

            var contrato = await _context.Contratos
                .Include(c => c.IdDesarrolladorNavigation)
                .Include(c => c.IdEmpresaNavigation)
                .FirstOrDefaultAsync(m => m.IdContrato == id);
            if (contrato == null)
            {
                return NotFound();
            }

            return View(contrato);
        }

        // POST: Contratoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Contratos == null)
            {
                return Problem("Entity set 'VideojuegosContext.Contratos'  is null.");
            }
            var contrato = await _context.Contratos.FindAsync(id);
            if (contrato != null)
            {
                _context.Contratos.Remove(contrato);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContratoExists(int id)
        {
          return (_context.Contratos?.Any(e => e.IdContrato == id)).GetValueOrDefault();
        }
    }
}
