using Microsoft.EntityFrameworkCore;
using PostoDeGasolina.Data;
using PostoDeGasolina.Models;
using PostoDeGasolina.Services.Interfaces;

namespace PostoDeGasolina.Services.Implementations
{
    public class VeiculosService : IVeiculosService
    {
        private readonly ApplicationDbContext _context;

        public VeiculosService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Veiculo>> BuscarVeiculos()
        {
            return await _context.Veiculos.ToListAsync();
        }

        public async Task CadastrarVeiculo(Veiculo veiculo)
        {
            _context.Add(veiculo);
            await _context.SaveChangesAsync();
        }

        public async Task<Veiculo> BuscarVeiculoPorId(int id)
        {
            return await _context.Veiculos.FirstOrDefaultAsync(v => v.Id == id);
        }

        public async Task RemoverVeiculo(int id)
        {
            var veiculo = await _context.Veiculos.FindAsync(id);
            if (veiculo != null)
            {
                _context.Veiculos.Remove(veiculo);
                await _context.SaveChangesAsync();
            }
        }
    }
}
