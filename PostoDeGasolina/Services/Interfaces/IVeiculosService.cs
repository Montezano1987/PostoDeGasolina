using PostoDeGasolina.Models;

namespace PostoDeGasolina.Services.Interfaces
{
    public interface IVeiculosService
    {
        Task<List<Veiculo>> BuscarVeiculos();
        Task CadastrarVeiculo(Veiculo veiculo);
        Task<Veiculo> BuscarVeiculoPorId(int id);
        Task RemoverVeiculo(int id);
    }
}
