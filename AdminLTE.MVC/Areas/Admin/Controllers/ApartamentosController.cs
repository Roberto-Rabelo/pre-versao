using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AdminLTE.MVC.Data;
using AdminLTE.MVC.Models;

namespace AdminLTE.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ApartamentosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ApartamentosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Apartamentos
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.apartamentos.Include(a => a.Condominio);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Admin/Apartamentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apartamento = await _context.apartamentos
                .Include(a => a.Condominio)
                .FirstOrDefaultAsync(m => m.ApartamentoId == id);
            if (apartamento == null)
            {
                return NotFound();
            }

            return View(apartamento);
        }

        // GET: Admin/Apartamentos/Create
        public IActionResult Create()
        {
            ViewData["CondominioId"] = new SelectList(_context.condominios, "CondominioId", "Nome");
            return View();
        }

        // POST: Admin/Apartamentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ApartamentoId,Nome,apartamento,Bloco,CondominioId")] Apartamento apartamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(apartamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CondominioId"] = new SelectList(_context.condominios, "CondominioId", "Nome", apartamento.CondominioId);
            return View(apartamento);
        }

        // GET: Admin/Apartamentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apartamento = await _context.apartamentos.FindAsync(id);
            if (apartamento == null)
            {
                return NotFound();
            }
            ViewData["CondominioId"] = new SelectList(_context.condominios, "CondominioId", "Nome", apartamento.CondominioId);
            return View(apartamento);
        }

        // POST: Admin/Apartamentos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ApartamentoId,Nome,apartamento,Bloco,CondominioId")] Apartamento apartamento)
        {
            if (id != apartamento.ApartamentoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(apartamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApartamentoExists(apartamento.ApartamentoId))
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
            ViewData["CondominioId"] = new SelectList(_context.condominios, "CondominioId", "Nome", apartamento.CondominioId);
            return View(apartamento);
        }

        // GET: Admin/Apartamentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apartamento = await _context.apartamentos
                .Include(a => a.Condominio)
                .FirstOrDefaultAsync(m => m.ApartamentoId == id);
            if (apartamento == null)
            {
                return NotFound();
            }

            return View(apartamento);
        }

        // POST: Admin/Apartamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var apartamento = await _context.apartamentos.FindAsync(id);
            _context.apartamentos.Remove(apartamento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApartamentoExists(int id)
        {
            return _context.apartamentos.Any(e => e.ApartamentoId == id);
        }
    }
}
