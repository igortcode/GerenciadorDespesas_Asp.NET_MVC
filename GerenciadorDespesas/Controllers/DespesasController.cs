using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GerenciadorDespesas.Data;
using GerenciadorDespesas.Models;
using X.PagedList;
using GerenciadorDespesas.Models.ViewModels;

namespace GerenciadorDespesas.Controllers
{
    public class DespesasController : Controller
    {
        private readonly Context _context;

        public DespesasController(Context context)
        {
            _context = context;
        }

        // GET: Despesas
        public async Task<IActionResult> Index(int? pagina)
        {
            const int itensPagina = 10;
            int numeroPagina = pagina ?? 1;

            ViewData["Meses"] = new SelectList(_context.Meses.Where(x => x.Id == x.Salario.MesId), "Id", "Nome");

            var context = _context.Despesas.Include(d => d.Mes).Include(d => d.TipoDespesa).OrderBy( d => d.MesId);
            return View(await context.ToPagedListAsync(numeroPagina, itensPagina));
        }


        // GET: Despesas/Create
        public IActionResult Create()
        {
            ViewData["MesId"] = new SelectList(_context.Meses, "Id", "Nome");
            ViewData["TipoDespesaId"] = new SelectList(_context.TipoDespesas, "Id", "Nome");
            return View();
        }

        // POST: Despesas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MesId,TipoDespesaId,Valor")] Despesa despesa)
        {
            if (ModelState.IsValid)
            {
                TempData["confirmacao"] = "Despesa cadastrada com sucesso!";
                _context.Add(despesa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MesId"] = new SelectList(_context.Meses, "Id", "Nome", despesa.MesId);
            ViewData["TipoDespesaId"] = new SelectList(_context.TipoDespesas, "Id", "Nome", despesa.TipoDespesaId);
            return View(despesa);
        }

        // GET: Despesas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var despesa = await _context.Despesas.FindAsync(id);
            if (despesa == null)
            {
                return NotFound();
            }
            ViewData["MesId"] = new SelectList(_context.Meses, "Id", "Nome", despesa.MesId);
            ViewData["TipoDespesaId"] = new SelectList(_context.TipoDespesas, "Id", "Nome", despesa.TipoDespesaId);
            return View(despesa);
        }

        // POST: Despesas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MesId,TipoDespesaId,Valor")] Despesa despesa)
        {
            if (id != despesa.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    TempData["confirmacao"] = "Despesa atualizada com sucesso!";
                    _context.Update(despesa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DespesaExists(despesa.Id))
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
            ViewData["MesId"] = new SelectList(_context.Meses, "Id", "Nome", despesa.MesId);
            ViewData["TipoDespesaId"] = new SelectList(_context.TipoDespesas, "Id", "Nome", despesa.TipoDespesaId);
            return View(despesa);
        }

        // POST: Despesas/Delete/5
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            TempData["confirmacao"] = "Despesa excluída com sucesso!";
            var despesa = await _context.Despesas.FindAsync(id);
            _context.Despesas.Remove(despesa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DespesaExists(int id)
        {
            return _context.Despesas.Any(e => e.Id == id);
        }

        public JsonResult GastosTotaisMes(int mesId)
        {
            GastosTotaisMesViewModel gastos = new GastosTotaisMesViewModel();
            gastos.ValorTotalGasto = _context.Despesas.Where(d => d.Mes.Id == mesId).Sum(d => d.Valor);
            gastos.Salario = _context.Salarios.Where(s => s.Mes.Id == mesId).Select(s => s.Valor).FirstOrDefault();

            return Json(gastos);
        }

        public JsonResult GastoMes(int mesId)
        {
            var query = from despesa in _context.Despesas
                        where despesa.Mes.Id == mesId
                        group despesa by despesa.TipoDespesa.Nome into g
                        select new
                        {
                            TiposDespesas = g.Key,
                            Valores = g.Sum(d => d.Valor)
                        };
            return Json(query);
        }
    }
}
