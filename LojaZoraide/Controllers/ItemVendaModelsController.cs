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
    public class ItemVendaModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ItemVendaModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ItemVendaModels
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ItemVendas.Include(i => i.ProdutoModel).Include(i => i.VendaModel);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ItemVendaModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ItemVendas == null)
            {
                return NotFound();
            }

            var itemVendaModel = await _context.ItemVendas
                .Include(i => i.ProdutoModel)
                .Include(i => i.VendaModel)
                .FirstOrDefaultAsync(m => m.VendaModelId == id);
            if (itemVendaModel == null)
            {
                return NotFound();
            }

            return View(itemVendaModel);
        }

        // GET: ItemVendaModels/Create
        public IActionResult Create()
        {
            ViewData["ProdutoModelId"] = new SelectList(_context.Produtos, "Id", "Id");
            ViewData["VendaModelId"] = new SelectList(_context.Vendas, "Id", "Id");
            return View();
        }

        // POST: ItemVendaModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProdutoModelId,VendaModelId,MetodoPagamento,ValorProduto,Desconto,QuantidadeProduto")] ItemVendaModel itemVendaModel)
        {
           
                _context.Add(itemVendaModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
             
            ViewData["ProdutoModelId"] = new SelectList(_context.Produtos, "Id", "Id", itemVendaModel.ProdutoModelId);
            ViewData["VendaModelId"] = new SelectList(_context.Vendas, "Id", "Id", itemVendaModel.VendaModelId);
            return View(itemVendaModel);
        }

        // GET: ItemVendaModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ItemVendas == null)
            {
                return NotFound();
            }

            var itemVendaModel = await _context.ItemVendas.FindAsync(id);
            if (itemVendaModel == null)
            {
                return NotFound();
            }
            ViewData["ProdutoModelId"] = new SelectList(_context.Produtos, "Id", "Id", itemVendaModel.ProdutoModelId);
            ViewData["VendaModelId"] = new SelectList(_context.Vendas, "Id", "Id", itemVendaModel.VendaModelId);
            return View(itemVendaModel);
        }

        // POST: ItemVendaModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("ProdutoModelId,VendaModelId,MetodoPagamento,ValorProduto,Desconto,QuantidadeProduto")] ItemVendaModel itemVendaModel)
        {
            if (id != itemVendaModel.VendaModelId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(itemVendaModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemVendaModelExists(itemVendaModel.VendaModelId))
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
            ViewData["ProdutoModelId"] = new SelectList(_context.Produtos, "Id", "Id", itemVendaModel.ProdutoModelId);
            ViewData["VendaModelId"] = new SelectList(_context.Vendas, "Id", "Id", itemVendaModel.VendaModelId);
            return View(itemVendaModel);
        }

        // GET: ItemVendaModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ItemVendas == null)
            {
                return NotFound();
            }

            var itemVendaModel = await _context.ItemVendas
                .Include(i => i.ProdutoModel)
                .Include(i => i.VendaModel)
                .FirstOrDefaultAsync(m => m.VendaModelId == id);
            if (itemVendaModel == null)
            {
                return NotFound();
            }

            return View(itemVendaModel);
        }

        // POST: ItemVendaModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (_context.ItemVendas == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ItemVendas'  is null.");
            }
            var itemVendaModel = await _context.ItemVendas.FindAsync(id);
            if (itemVendaModel != null)
            {
                _context.ItemVendas.Remove(itemVendaModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemVendaModelExists(int? id)
        {
          return (_context.ItemVendas?.Any(e => e.VendaModelId == id)).GetValueOrDefault();
        }
    }
}
