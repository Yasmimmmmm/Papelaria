using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Papelaria.Data;
using Papelaria.Models;

namespace Papelaria.Controllers
{
    public class CadVendasController : Controller
    {
        private readonly Context _context;

        public CadVendasController(Context context)
        {
            _context = context;
        }

        // GET: CadVendas
        public async Task<IActionResult> Index()
        {
            var context = _context.CadVendas.Include(c => c.Cliente).Include(c => c.Produto);
            return View(await context.ToListAsync());
        }

        // GET: CadVendas/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.CadVendas == null)
            {
                return NotFound();
            }

            var cadVenda = await _context.CadVendas
                .Include(c => c.Cliente)
                .Include(c => c.Produto)
                .FirstOrDefaultAsync(m => m.CadVendaId == id);
            if (cadVenda == null)
            {
                return NotFound();
            }

            return View(cadVenda);
        }

        // GET: CadVendas/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "Nome");
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "ProdutoId", "ProdutoNome");
            return View();
        }

        // POST: CadVendas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CadVendaId,NotaVenda,DataHora,ClienteId,ProdutoId,Quantidade,Preco")] CadVenda cadVenda)
        {
            if (ModelState.IsValid)
            {
                cadVenda.CadVendaId = Guid.NewGuid();
                _context.Add(cadVenda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "Nome", cadVenda.ClienteId);
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "ProdutoId", "ProdutoNome", cadVenda.ProdutoId);
            return View(cadVenda);
        }

        // GET: CadVendas/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.CadVendas == null)
            {
                return NotFound();
            }

            var cadVenda = await _context.CadVendas.FindAsync(id);
            if (cadVenda == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "Nome", cadVenda.ClienteId);
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "ProdutoId", "ProdutoNome", cadVenda.ProdutoId);
            return View(cadVenda);
        }

        // POST: CadVendas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("CadVendaId,NotaVenda,DataHora,ClienteId,ProdutoId,Quantidade,Preco")] CadVenda cadVenda)
        {
            if (id != cadVenda.CadVendaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cadVenda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CadVendaExists(cadVenda.CadVendaId))
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
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "Nome", cadVenda.ClienteId);
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "ProdutoId", "ProdutoNome", cadVenda.ProdutoId);
            return View(cadVenda);
        }

        // GET: CadVendas/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.CadVendas == null)
            {
                return NotFound();
            }

            var cadVenda = await _context.CadVendas
                .Include(c => c.Cliente)
                .Include(c => c.Produto)
                .FirstOrDefaultAsync(m => m.CadVendaId == id);
            if (cadVenda == null)
            {
                return NotFound();
            }

            return View(cadVenda);
        }

        // POST: CadVendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.CadVendas == null)
            {
                return Problem("Entity set 'Context.CadVendas'  is null.");
            }
            var cadVenda = await _context.CadVendas.FindAsync(id);
            if (cadVenda != null)
            {
                _context.CadVendas.Remove(cadVenda);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CadVendaExists(Guid id)
        {
          return (_context.CadVendas?.Any(e => e.CadVendaId == id)).GetValueOrDefault();
        }
    }
}
