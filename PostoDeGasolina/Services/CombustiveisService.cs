using Microsoft.EntityFrameworkCore;
using PostoDeGasolina.Data;
using PostoDeGasolina.Models;

namespace PostoDeGasolina.Services
{
    public class CombustiveisService
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
        
    }
}
