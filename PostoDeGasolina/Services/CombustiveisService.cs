using Microsoft.EntityFrameworkCore;
using PostoDeGasolina.Data;
using PostoDeGasolina.Models;
using PostoDeGasolina.Services.Interfaces;

namespace PostoDeGasolina.Services.Implementations
{
    public class CombustiveisService : ICombustiveisService
    {
        private readonly ApplicationDbContext _context;

        public CombustiveisService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Combustivel>> BuscarCombustiveis()
        {
            return await _context.Combustiveis.ToListAsync();
        }

        public async Task CadastrarCombustivel(Combustivel combustivel)
        {
            _context.Add(combustivel);
            await _context.SaveChangesAsync();
        }

        public async Task<Combustivel> BuscarCombustivelPorId(int id)
        {
            return await _context.Combustiveis.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task RemoverCombustivel(int id)
        {
            var combustivel = await _context.Combustiveis.FindAsync(id);
            if (combustivel != null)
            {
                _context.Combustiveis.Remove(combustivel);
                await _context.SaveChangesAsync();
            }
        }
    }
}
