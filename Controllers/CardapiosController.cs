using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MenuEduca01.Data;
using MenuEduca01.Models;

namespace MenuEduca01.Controllers
{
    public class CardapiosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CardapiosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Cardapios
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cardapios.ToListAsync());
        }

        // GET: Cardapios/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cardapio = await _context.Cardapios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cardapio == null)
            {
                return NotFound();
            }

            return View(cardapio);
        }

        // GET: Cardapios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cardapios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Categoria,NomeRefeicao,Imagem,Descricao,Ingredientes,Calorias,Data,UsuariosId")] Cardapio cardapio)
        {
            if (ModelState.IsValid)
            {
                cardapio.Id = Guid.NewGuid();
                _context.Add(cardapio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cardapio);
        }

        // GET: Cardapios/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cardapio = await _context.Cardapios.FindAsync(id);
            if (cardapio == null)
            {
                return NotFound();
            }
            return View(cardapio);
        }

        // POST: Cardapios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Categoria,NomeRefeicao,Imagem,Descricao,Ingredientes,Calorias,Data,UsuariosId")] Cardapio cardapio)
        {
            if (id != cardapio.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cardapio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CardapioExists(cardapio.Id))
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
            return View(cardapio);
        }

        // GET: Cardapios/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cardapio = await _context.Cardapios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cardapio == null)
            {
                return NotFound();
            }

            return View(cardapio);
        }

        // POST: Cardapios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var cardapio = await _context.Cardapios.FindAsync(id);
            if (cardapio != null)
            {
                _context.Cardapios.Remove(cardapio);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CardapioExists(Guid id)
        {
            return _context.Cardapios.Any(e => e.Id == id);
        }
    }
}
