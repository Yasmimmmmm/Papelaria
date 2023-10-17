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
    public class CadComprasController : Controller
    {
        private readonly Context _context;

        public CadComprasController(Context context)
        {
            _context = context;
        }

        // GET: CadCompras
        public async Task<IActionResult> Index()
        {
            var context = _context.CadCompras.Include(c => c.Fornecedor).Include(c => c.Produto);
            return View(await context.ToListAsync());
        }

        // GET: CadCompras/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.CadCompras == null)
            {
                return NotFound();
            }

            var cadCompra = await _context.CadCompras
                .Include(c => c.Fornecedor)
                .Include(c => c.Produto)
                .FirstOrDefaultAsync(m => m.CadCompraId == id);
            if (cadCompra == null)
            {
                return NotFound();
            }

            return View(cadCompra);
        }

        // GET: CadCompras/Create
        public IActionResult Create()
        {
            ViewData["FornecedorId"] = new SelectList(_context.Fornecedores, "FornecedorId", "FornecedorNome");
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "ProdutoId", "ProdutoNome");
            return View();
        }

        // POST: CadCompras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CadCompraId,NotaCompra,DataHora,FornecedorId,ProdutoId,Quantidade,Preco")] CadCompra cadCompra)
        {
            if (ModelState.IsValid)
            {
                cadCompra.CadCompraId = Guid.NewGuid();
                _context.Add(cadCompra);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FornecedorId"] = new SelectList(_context.Fornecedores, "FornecedorId", "FornecedorNome", cadCompra.FornecedorId);
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "ProdutoId", "ProdutoNome", cadCompra.ProdutoId);
            return View(cadCompra);
        }

        // GET: CadCompras/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.CadCompras == null)
            {
                return NotFound();
            }

            var cadCompra = await _context.CadCompras.FindAsync(id);
            if (cadCompra == null)
            {
                return NotFound();
            }
            ViewData["FornecedorId"] = new SelectList(_context.Fornecedores, "FornecedorId", "FornecedorNome", cadCompra.FornecedorId);
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "ProdutoId", "ProdutoNome", cadCompra.ProdutoId);
            return View(cadCompra);
        }

        // POST: CadCompras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("CadCompraId,NotaCompra,DataHora,FornecedorId,ProdutoId,Quantidade,Preco")] CadCompra cadCompra)
        {
            if (id != cadCompra.CadCompraId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cadCompra);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CadCompraExists(cadCompra.CadCompraId))
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
            ViewData["FornecedorId"] = new SelectList(_context.Fornecedores, "FornecedorId", "FornecedorNome", cadCompra.FornecedorId);
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "ProdutoId", "ProdutoNome", cadCompra.ProdutoId);
            return View(cadCompra);
        }

        // GET: CadCompras/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.CadCompras == null)
            {
                return NotFound();
            }

            var cadCompra = await _context.CadCompras
                .Include(c => c.Fornecedor)
                .Include(c => c.Produto)
                .FirstOrDefaultAsync(m => m.CadCompraId == id);
            if (cadCompra == null)
            {
                return NotFound();
            }

            return View(cadCompra);
        }

        // POST: CadCompras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.CadCompras == null)
            {
                return Problem("Entity set 'Context.CadCompras'  is null.");
            }
            var cadCompra = await _context.CadCompras.FindAsync(id);
            if (cadCompra != null)
            {
                _context.CadCompras.Remove(cadCompra);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CadCompraExists(Guid id)
        {
          return (_context.CadCompras?.Any(e => e.CadCompraId == id)).GetValueOrDefault();
        }
    }
}
