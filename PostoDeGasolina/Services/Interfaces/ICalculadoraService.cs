namespace PostoDeGasolina.Services.Interfaces
{
    public interface ICalculadoraService
    {
        string CalcularMelhorCombustivel(decimal precoGasolina, decimal precoAlcool);
    }
}
