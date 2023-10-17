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
    public class CategoriaProdsController : Controller
    {
        private readonly Context _context;

        public CategoriaProdsController(Context context)
        {
            _context = context;
        }

        // GET: CategoriaProds
        public async Task<IActionResult> Index()
        {
              return _context.CategoriaProds != null ? 
                          View(await _context.CategoriaProds.ToListAsync()) :
                          Problem("Entity set 'Context.CategoriaProds'  is null.");
        }

        // GET: CategoriaProds/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.CategoriaProds == null)
            {
                return NotFound();
            }

            var categoriaProd = await _context.CategoriaProds
                .FirstOrDefaultAsync(m => m.CategoriaProdId == id);
            if (categoriaProd == null)
            {
                return NotFound();
            }

            return View(categoriaProd);
        }

        // GET: CategoriaProds/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CategoriaProds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoriaProdId,CategoriaProdName")] CategoriaProd categoriaProd)
        {
            if (ModelState.IsValid)
            {
                categoriaProd.CategoriaProdId = Guid.NewGuid();
                _context.Add(categoriaProd);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categoriaProd);
        }

        // GET: CategoriaProds/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.CategoriaProds == null)
            {
                return NotFound();
            }

            var categoriaProd = await _context.CategoriaProds.FindAsync(id);
            if (categoriaProd == null)
            {
                return NotFound();
            }
            return View(categoriaProd);
        }

        // POST: CategoriaProds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("CategoriaProdId,CategoriaProdName")] CategoriaProd categoriaProd)
        {
            if (id != categoriaProd.CategoriaProdId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categoriaProd);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoriaProdExists(categoriaProd.CategoriaProdId))
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
            return View(categoriaProd);
        }

        // GET: CategoriaProds/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.CategoriaProds == null)
            {
                return NotFound();
            }

            var categoriaProd = await _context.CategoriaProds
                .FirstOrDefaultAsync(m => m.CategoriaProdId == id);
            if (categoriaProd == null)
            {
                return NotFound();
            }

            return View(categoriaProd);
        }

        // POST: CategoriaProds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.CategoriaProds == null)
            {
                return Problem("Entity set 'Context.CategoriaProds'  is null.");
            }
            var categoriaProd = await _context.CategoriaProds.FindAsync(id);
            if (categoriaProd != null)
            {
                _context.CategoriaProds.Remove(categoriaProd);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoriaProdExists(Guid id)
        {
          return (_context.CategoriaProds?.Any(e => e.CategoriaProdId == id)).GetValueOrDefault();
        }
    }
}
