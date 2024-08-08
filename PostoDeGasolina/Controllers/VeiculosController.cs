using Microsoft.AspNetCore.Mvc;
using PostoDeGasolina.Services.Interfaces;
using PostoDeGasolina.Models;
using Microsoft.EntityFrameworkCore;


namespace PostoDeGasolina.Controllers
{
    public class VeiculosController : Controller
    {
        private readonly IVeiculosService _veiculosService;

        public VeiculosController(IVeiculosService veiculosService)
        {
            _veiculosService = veiculosService;
            
        }

        public async Task<IActionResult> Index()
        {
            var veiculos = await _veiculosService.BuscarVeiculos();
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
                await _veiculosService.CadastrarVeiculo(veiculo);
                ViewBag.Message = "Veículo cadastrado com sucesso!";
                return RedirectToAction("Index");
            }
            return View(veiculo);
        }

		public IActionResult BuscarVeiculoPorId()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> BuscarVeiculoPorId(int id)
		{
			
			var veiculo = await _veiculosService.BuscarVeiculoPorId(id);

			if (veiculo == null)
			{
				ViewBag.Message = "Veículo não encontrado.";
				return View();
			}

			return View("DetalhesVeiculo", veiculo);
		}

		public async Task<IActionResult> Delete(int? id)
        {
      
            var veiculo = await _veiculosService.BuscarVeiculoPorId(id.Value);
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
            await _veiculosService.RemoverVeiculo(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
