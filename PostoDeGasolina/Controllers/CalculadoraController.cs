using Microsoft.AspNetCore.Mvc;
using PostoDeGasolina.Services.Interfaces;

namespace PostoDeGasolina.Controllers
{
    public class CalculadoraController : Controller
    {
        private readonly ICalculadoraService _calculadoraService;

        public CalculadoraController(ICalculadoraService calculadoraService)
        {
            _calculadoraService = calculadoraService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Calcular(decimal precoGasolina, decimal precoAlcool)
        {
            var resultado = _calculadoraService.CalcularMelhorCombustivel(precoGasolina, precoAlcool);
            ViewBag.Resultado = resultado;
            return View("Index");
        }
    }
}
