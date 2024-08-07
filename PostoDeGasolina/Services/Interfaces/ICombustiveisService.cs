using PostoDeGasolina.Models;

namespace PostoDeGasolina.Services.Interfaces
{
    public interface ICombustiveisService
    {
        Task<List<Combustivel>> BuscarCombustiveis();
        Task CadastrarCombustivel(Combustivel combustivel);
        Task<Combustivel> BuscarCombustivelPorId(int id);
        Task RemoverCombustivel(int id);
    }
}
