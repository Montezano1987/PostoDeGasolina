using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PostoDeGasolina.Data;
using PostoDeGasolina.Models;

namespace PostoDeGasolina.Controllers
{
    public class VeiculosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VeiculosController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var veiculos = await _context.Veiculos.ToListAsync();
            return View(veiculos);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Modelo,Marca,Ano")] Veiculo veiculo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(veiculo);
                await _context.SaveChangesAsync();
                ViewBag.Message = "Veículo cadastrado com sucesso!";
                return RedirectToAction("Index");
            }
            return View(veiculo);
        }

		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var veiculo = await _context.Veiculos
				.FirstOrDefaultAsync(v => v.Id == id);
			if (veiculo == null)
			{
				return NotFound();
			}

			return View(veiculo);
		}

		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var veiculo = await _context.Veiculos.FindAsync(id);
			_context.Veiculos.Remove(veiculo);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}
	}
}