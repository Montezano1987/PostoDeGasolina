using Microsoft.AspNetCore.Mvc;

namespace PostoDeGasolina.Controllers
{
    public class CalculadoraController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Calcular(decimal precoGasolina, decimal precoAlcool)
        {
            var rendimentoAlcool = precoAlcool / 0.7m;
            var resultado = rendimentoAlcool < precoGasolina ? "Álcool" : "Gasolina";

            ViewBag.Resultado = resultado;
            return View("Index");
        }
    }
}
