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
    public class CadastroUsuariosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CadastroUsuariosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CadastroUsuarios
        public async Task<IActionResult> Index()
        {
            return View(await _context.Usuarios.ToListAsync());
        }

        // GET: CadastroUsuarios/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastroUsuario = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.CadastroUsuarioId == id);
            if (cadastroUsuario == null)
            {
                return NotFound();
            }

            return View(cadastroUsuario);
        }

        // GET: CadastroUsuarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CadastroUsuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CadastroUsuarioId,NomeCompleto,CPF,Email,Senha,TipoUsuario")] CadastroUsuario cadastroUsuario)
        {
            if (ModelState.IsValid)
            {
                cadastroUsuario.CadastroUsuarioId = Guid.NewGuid();
                _context.Add(cadastroUsuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cadastroUsuario);
        }

        // GET: CadastroUsuarios/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastroUsuario = await _context.Usuarios.FindAsync(id);
            if (cadastroUsuario == null)
            {
                return NotFound();
            }
            return View(cadastroUsuario);
        }

        // POST: CadastroUsuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("CadastroUsuarioId,NomeCompleto,CPF,Email,Senha,TipoUsuario")] CadastroUsuario cadastroUsuario)
        {
            if (id != cadastroUsuario.CadastroUsuarioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cadastroUsuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CadastroUsuarioExists(cadastroUsuario.CadastroUsuarioId))
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
            return View(cadastroUsuario);
        }

        // GET: CadastroUsuarios/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastroUsuario = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.CadastroUsuarioId == id);
            if (cadastroUsuario == null)
            {
                return NotFound();
            }

            return View(cadastroUsuario);
        }

        // POST: CadastroUsuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var cadastroUsuario = await _context.Usuarios.FindAsync(id);
            if (cadastroUsuario != null)
            {
                _context.Usuarios.Remove(cadastroUsuario);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CadastroUsuarioExists(Guid id)
        {
            return _context.Usuarios.Any(e => e.CadastroUsuarioId == id);
        }
    }
}
