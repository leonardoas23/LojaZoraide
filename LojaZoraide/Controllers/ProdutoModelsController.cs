﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LojaZoraide.Data;
using LojaZoraide.Models;
using LojaZoraide.Arquitetura.Extensoes;

namespace LojaZoraide.Controllers
{
    public class ProdutoModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProdutoModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ProdutoModels
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Produtos.Include(p => p.CategoriaModel);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ProdutoModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Produtos == null)
            {
                return NotFound();
            }

            var produtoModel = await _context.Produtos
                .Include(p => p.CategoriaModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produtoModel == null)
            {
                return NotFound();
            }

            return View(produtoModel);
        }

        // GET: ProdutoModels/Create
        public IActionResult Create()
        {
            ViewData["CategoriaModelId"] = new SelectList(_context.Categorias, "Id", "Id");
            return View();
        }

        // POST: ProdutoModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Valor,Quantidade,Descricao,Estado,Foto,CategoriaModelId")] ProdutoModel produtoModel)
        {
            //if (ModelState.IsValid)
            //{
            produtoModel.FotoDB = await produtoModel.Foto.GetBytes();
            _context.Add(produtoModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            //}
            ViewData["CategoriaModelId"] = new SelectList(_context.Categorias, "Id", "Id", produtoModel.CategoriaModelId);
            return View(produtoModel);
        }

        // GET: ProdutoModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Produtos == null)
            {
                return NotFound();
            }

            var produtoModel = await _context.Produtos.FindAsync(id);
            if (produtoModel == null)
            {
                return NotFound();
            }
            ViewData["CategoriaModelId"] = new SelectList(_context.Categorias, "Id", "Id", produtoModel.CategoriaModelId);
            return View(produtoModel);
        }

        // POST: ProdutoModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Valor,Quantidade,Descricao,Estado,Foto,CategoriaModelId")] ProdutoModel produtoModel)
        {
            if (id != produtoModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produtoModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdutoModelExists(produtoModel.Id))
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
            ViewData["CategoriaModelId"] = new SelectList(_context.Categorias, "Id", "Id", produtoModel.CategoriaModelId);
            return View(produtoModel);
        }

        // GET: ProdutoModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Produtos == null)
            {
                return NotFound();
            }

            var produtoModel = await _context.Produtos
                .Include(p => p.CategoriaModel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produtoModel == null)
            {
                return NotFound();
            }

            return View(produtoModel);
        }

        // POST: ProdutoModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Produtos == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Produtos'  is null.");
            }
            var produtoModel = await _context.Produtos.FindAsync(id);
            if (produtoModel != null)
            {
                _context.Produtos.Remove(produtoModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdutoModelExists(int id)
        {
          return (_context.Produtos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
