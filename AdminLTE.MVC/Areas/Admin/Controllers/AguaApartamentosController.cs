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
    public class AguaApartamentosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AguaApartamentosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/AguaApartamentos
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.aguaApartamentos.Include(a => a.Apartamento);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Admin/AguaApartamentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aguaApartamento = await _context.aguaApartamentos
                .Include(a => a.Apartamento)
                .FirstOrDefaultAsync(m => m.AguaApartamentoId == id);
            if (aguaApartamento == null)
            {
                return NotFound();
            }

            return View(aguaApartamento);
        }

        // GET: Admin/AguaApartamentos/Create
        public IActionResult Create()
        {
            ViewData["ApartamentoId"] = new SelectList(_context.apartamentos, "ApartamentoId", "Bloco");
            return View();
        }

        // POST: Admin/AguaApartamentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AguaApartamentoId,Mes,Ano,dt_leitura_atual,re_leitura_atual,re_valor_atual,FotoPath,ApartamentoId")] AguaApartamento aguaApartamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aguaApartamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApartamentoId"] = new SelectList(_context.apartamentos, "ApartamentoId", "Bloco", aguaApartamento.ApartamentoId);
            return View(aguaApartamento);
        }

        // GET: Admin/AguaApartamentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aguaApartamento = await _context.aguaApartamentos.FindAsync(id);
            if (aguaApartamento == null)
            {
                return NotFound();
            }
            ViewData["ApartamentoId"] = new SelectList(_context.apartamentos, "ApartamentoId", "Bloco", aguaApartamento.ApartamentoId);
            return View(aguaApartamento);
        }

        // POST: Admin/AguaApartamentos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AguaApartamentoId,Mes,Ano,dt_leitura_atual,re_leitura_atual,re_valor_atual,FotoPath,ApartamentoId")] AguaApartamento aguaApartamento)
        {
            if (id != aguaApartamento.AguaApartamentoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aguaApartamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AguaApartamentoExists(aguaApartamento.AguaApartamentoId))
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
            ViewData["ApartamentoId"] = new SelectList(_context.apartamentos, "ApartamentoId", "Bloco", aguaApartamento.ApartamentoId);
            return View(aguaApartamento);
        }

        // GET: Admin/AguaApartamentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aguaApartamento = await _context.aguaApartamentos
                .Include(a => a.Apartamento)
                .FirstOrDefaultAsync(m => m.AguaApartamentoId == id);
            if (aguaApartamento == null)
            {
                return NotFound();
            }

            return View(aguaApartamento);
        }

        // POST: Admin/AguaApartamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aguaApartamento = await _context.aguaApartamentos.FindAsync(id);
            _context.aguaApartamentos.Remove(aguaApartamento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AguaApartamentoExists(int id)
        {
            return _context.aguaApartamentos.Any(e => e.AguaApartamentoId == id);
        }
    }
}
