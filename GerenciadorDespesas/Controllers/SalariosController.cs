using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GerenciadorDespesas.Data;
using GerenciadorDespesas.Models;

namespace GerenciadorDespesas.Controllers
{
    public class SalariosController : Controller
    {
        private readonly Context _context;

        public SalariosController(Context context)
        {
            _context = context;
        }

        // GET: Salarios
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var context = _context.Salarios.Include(s => s.Mes);
            return View(await context.ToListAsync());
        }

        public async Task<IActionResult> Index(string txtProcurar)
        {
            if (!String.IsNullOrEmpty(txtProcurar))
                return View(await _context.Salarios.Include(s => s.Mes).Where(s => s.Mes.Nome.ToUpper().Contains(txtProcurar)).ToListAsync());
            else
                return View(await _context.Salarios.Include(s => s.Mes).ToListAsync());
        }

        // GET: Salarios/Create
        public IActionResult Create()
        {
            ViewData["MesId"] = new SelectList(_context.Meses.Where(x => x.Id != x.Salario.MesId), "Id", "Nome");
            return View();
        }

        // POST: Salarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MesId,Valor")] Salario salario)
        {
            if (ModelState.IsValid)
            {
                TempData["confirmacao"] = "Salário cadastrado com sucesso!";
                _context.Add(salario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MesId"] = new SelectList(_context.Meses.Where(x => x.Id != x.Salario.MesId), "Id", "Nome", salario.MesId);
            return View(salario);
        }

        // GET: Salarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salario = await _context.Salarios.FindAsync(id);
            if (salario == null)
            {
                return NotFound();
            }
            ViewData["MesId"] = new SelectList(_context.Meses.Where(x => x.Id == x.Salario.MesId), "Id", "Nome", salario.MesId);
            return View(salario);
        }

        // POST: Salarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MesId,Valor")] Salario salario)
        {
            if (id != salario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    TempData["confirmacao"] = "Salário atualizado com sucesso!";
                    _context.Update(salario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalarioExists(salario.Id))
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
            ViewData["MesId"] = new SelectList(_context.Meses.Where(x => x.Id == x.Salario.MesId), "Id", "Nome", salario.MesId);
            return View(salario);
        }

        // POST: Salarios/Delete/5
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            TempData["confirmacao"] = "Salário excluído com sucesso!";
            var salario = await _context.Salarios.FindAsync(id);
            _context.Salarios.Remove(salario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalarioExists(int id)
        {
            return _context.Salarios.Any(e => e.Id == id);
        }
    }
}
