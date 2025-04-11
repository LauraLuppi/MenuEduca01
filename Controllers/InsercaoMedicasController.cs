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
    public class InsercaoMedicasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InsercaoMedicasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: InsercaoMedicas
        public async Task<IActionResult> Index()
        {
            return View(await _context.InsercaoMedicas.ToListAsync());
        }

        // GET: InsercaoMedicas/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var insercaoMedica = await _context.InsercaoMedicas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (insercaoMedica == null)
            {
                return NotFound();
            }

            return View(insercaoMedica);
        }

        // GET: InsercaoMedicas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InsercaoMedicas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UsuariosId,Descricao,receitaMedica,DataCadastro,Notificacao")] InsercaoMedica insercaoMedica)
        {
            if (ModelState.IsValid)
            {
                insercaoMedica.Id = Guid.NewGuid();
                _context.Add(insercaoMedica);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(insercaoMedica);
        }

        // GET: InsercaoMedicas/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var insercaoMedica = await _context.InsercaoMedicas.FindAsync(id);
            if (insercaoMedica == null)
            {
                return NotFound();
            }
            return View(insercaoMedica);
        }

        // POST: InsercaoMedicas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,UsuariosId,Descricao,receitaMedica,DataCadastro,Notificacao")] InsercaoMedica insercaoMedica)
        {
            if (id != insercaoMedica.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(insercaoMedica);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InsercaoMedicaExists(insercaoMedica.Id))
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
            return View(insercaoMedica);
        }

        // GET: InsercaoMedicas/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var insercaoMedica = await _context.InsercaoMedicas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (insercaoMedica == null)
            {
                return NotFound();
            }

            return View(insercaoMedica);
        }

        // POST: InsercaoMedicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var insercaoMedica = await _context.InsercaoMedicas.FindAsync(id);
            if (insercaoMedica != null)
            {
                _context.InsercaoMedicas.Remove(insercaoMedica);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InsercaoMedicaExists(Guid id)
        {
            return _context.InsercaoMedicas.Any(e => e.Id == id);
        }
    }
}
