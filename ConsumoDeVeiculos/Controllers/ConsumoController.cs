using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ConsumoDeVeiculos.Models;

namespace ConsumoDeVeiculos.Controllers
{
    public class ConsumoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ConsumoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Consumo
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Consumo.Include(c => c.Veiculo);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Consumo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Consumo == null)
            {
                return NotFound();
            }

            var consumo = await _context.Consumo
                .Include(c => c.Veiculo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (consumo == null)
            {
                return NotFound();
            }

            return View(consumo);
        }

        // GET: Consumo/Create
        public IActionResult Create()
        {
            ViewData["VeiculoId"] = new SelectList(_context.Veiculos, "Id", "Nome");
            return View();
        }

        // POST: Consumo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Descricao,Data,Km,Valor,Combustivel,VeiculoId")] Consumo consumo)
        {
            _context.Add(new Consumo()
            {
                Descricao = consumo.Descricao,
                Data = consumo.Data,
                Km = consumo.Km,
                Valor = consumo.Valor,
                Combustivel = consumo.Combustivel,
                VeiculoId = consumo.VeiculoId
            });
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Consumo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Consumo == null)
            {
                return NotFound();
            }

            var consumo = await _context.Consumo.FindAsync(id);
            if (consumo == null)
            {
                return NotFound();
            }
            ViewData["VeiculoId"] = new SelectList(_context.Veiculos, "Id", "Nome", consumo.VeiculoId);
            return View(consumo);
        }

        // POST: Consumo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descricao,Data,Km,Valor,Combustivel,VeiculoId")] Consumo consumo)
        {
            if (id != consumo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(consumo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConsumoExists(consumo.Id))
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
            ViewData["VeiculoId"] = new SelectList(_context.Veiculos, "Id", "Nome", consumo.VeiculoId);
            return View(consumo);
        }

        // GET: Consumo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Consumo == null)
            {
                return NotFound();
            }

            var consumo = await _context.Consumo
                .Include(c => c.Veiculo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (consumo == null)
            {
                return NotFound();
            }

            return View(consumo);
        }

        // POST: Consumo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Consumo == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Consumo'  is null.");
            }
            var consumo = await _context.Consumo.FindAsync(id);
            if (consumo != null)
            {
                _context.Consumo.Remove(consumo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConsumoExists(int id)
        {
            return _context.Consumo.Any(e => e.Id == id);
        }
    }
}
