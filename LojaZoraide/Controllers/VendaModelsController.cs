using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LojaZoraide.Data;
using LojaZoraide.Models;

namespace LojaZoraide.Controllers
{
    public class VendaModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VendaModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: VendaModels
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Vendas.Include(v => v.ClienteModel);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: VendaModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Vendas == null)
            {
                return NotFound();
            }

            var vendaModel = await _context.Vendas
                .Include(v => v.ClienteModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vendaModel == null)
            {
                return NotFound();
            }

            return View(vendaModel);
        }

        // GET: VendaModels/Create
        public IActionResult Create()
        {
            ViewData["ClienteModelId"] = new SelectList(_context.Clientes, "Id", "Id");
            return View();
        }

        // POST: VendaModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DataVenda,TotalVenda,ClienteModelId")] VendaModel vendaModel)
        {
            
                _context.Add(vendaModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
            ViewData["ClienteModelId"] = new SelectList(_context.Clientes, "Id", "Id", vendaModel.ClienteModelId);
            return View(vendaModel);
        }

        // GET: VendaModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Vendas == null)
            {
                return NotFound();
            }

            var vendaModel = await _context.Vendas.FindAsync(id);
            if (vendaModel == null)
            {
                return NotFound();
            }
            ViewData["ClienteModelId"] = new SelectList(_context.Clientes, "Id", "Id", vendaModel.ClienteModelId);
            return View(vendaModel);
        }

        // POST: VendaModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DataVenda,TotalVenda,ClienteModelId")] VendaModel vendaModel)
        {
            if (id != vendaModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vendaModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VendaModelExists(vendaModel.Id))
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
            ViewData["ClienteModelId"] = new SelectList(_context.Clientes, "Id", "Id", vendaModel.ClienteModelId);
            return View(vendaModel);
        }

        // GET: VendaModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Vendas == null)
            {
                return NotFound();
            }

            var vendaModel = await _context.Vendas
                .Include(v => v.ClienteModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vendaModel == null)
            {
                return NotFound();
            }

            return View(vendaModel);
        }

        // POST: VendaModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Vendas == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Vendas'  is null.");
            }
            var vendaModel = await _context.Vendas.FindAsync(id);
            if (vendaModel != null)
            {
                _context.Vendas.Remove(vendaModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VendaModelExists(int id)
        {
          return (_context.Vendas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
