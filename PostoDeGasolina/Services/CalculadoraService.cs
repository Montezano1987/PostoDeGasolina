using PostoDeGasolina.Services.Interfaces;

namespace PostoDeGasolina.Services.Implementations
{
    public class CalculadoraService : ICalculadoraService
    {
        public string CalcularMelhorCombustivel(decimal precoGasolina, decimal precoAlcool)
        {
            var rendimentoAlcool = precoAlcool / 0.7m;
            return rendimentoAlcool < precoGasolina ? "Álcool" : "Gasolina";
        }
    }
}
