using Microsoft.AspNetCore.Mvc;
using PostoDeGasolina.Services.Interfaces;
using PostoDeGasolina.Models;

namespace PostoDeGasolina.Controllers
{
    public class CombustiveisController : Controller
    {
        private readonly ICombustiveisService _combustiveisService;

        public CombustiveisController(ICombustiveisService combustiveisService)
        {
            _combustiveisService = combustiveisService;
        }

        public async Task<IActionResult> Index()
        {
            var combustiveis = await _combustiveisService.BuscarCombustiveis();
            return View(combustiveis);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Preco")] Combustivel combustivel)
        {
            if (ModelState.IsValid)
            {
                await _combustiveisService.CadastrarCombustivel(combustivel);
                ViewBag.Message = "Combustível cadastrado com sucesso!";
                return RedirectToAction("Index");
            }
            return View(combustivel);
        }

        public async Task<IActionResult> Delete(int? id)
        {

            var combustivel = await _combustiveisService.BuscarCombustivelPorId(id.Value);
            if (combustivel == null)
            {
                return NotFound();
            }

            return View(combustivel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _combustiveisService.RemoverCombustivel(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
