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
    public class AguaCondominiosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AguaCondominiosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/AguaCondominios
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.aguaCondominios.Include(a => a.Condominio);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Admin/AguaCondominios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aguaCondominio = await _context.aguaCondominios
                .Include(a => a.Condominio)
                .FirstOrDefaultAsync(m => m.AguaCondominioId == id);
            if (aguaCondominio == null)
            {
                return NotFound();
            }

            return View(aguaCondominio);
        }

        // GET: Admin/AguaCondominios/Create
        public IActionResult Create()
        {
            ViewData["CondominioId"] = new SelectList(_context.condominios, "CondominioId", "Nome");
            return View();
        }

        // POST: Admin/AguaCondominios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AguaCondominioId,Mes,Ano,dt_leitura_atual,re_leitura_atual,re_valor_atual,FotoPath,CondominioId")] AguaCondominio aguaCondominio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aguaCondominio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CondominioId"] = new SelectList(_context.condominios, "CondominioId", "Nome", aguaCondominio.CondominioId);
            return View(aguaCondominio);
        }

        // GET: Admin/AguaCondominios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aguaCondominio = await _context.aguaCondominios.FindAsync(id);
            if (aguaCondominio == null)
            {
                return NotFound();
            }
            ViewData["CondominioId"] = new SelectList(_context.condominios, "CondominioId", "Nome", aguaCondominio.CondominioId);
            return View(aguaCondominio);
        }

        // POST: Admin/AguaCondominios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AguaCondominioId,Mes,Ano,dt_leitura_atual,re_leitura_atual,re_valor_atual,FotoPath,CondominioId")] AguaCondominio aguaCondominio)
        {
            if (id != aguaCondominio.AguaCondominioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aguaCondominio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AguaCondominioExists(aguaCondominio.AguaCondominioId))
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
            ViewData["CondominioId"] = new SelectList(_context.condominios, "CondominioId", "Nome", aguaCondominio.CondominioId);
            return View(aguaCondominio);
        }

        // GET: Admin/AguaCondominios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aguaCondominio = await _context.aguaCondominios
                .Include(a => a.Condominio)
                .FirstOrDefaultAsync(m => m.AguaCondominioId == id);
            if (aguaCondominio == null)
            {
                return NotFound();
            }

            return View(aguaCondominio);
        }

        // POST: Admin/AguaCondominios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aguaCondominio = await _context.aguaCondominios.FindAsync(id);
            _context.aguaCondominios.Remove(aguaCondominio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AguaCondominioExists(int id)
        {
            return _context.aguaCondominios.Any(e => e.AguaCondominioId == id);
        }
    }
}
