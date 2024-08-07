using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using PostoDeGasolina.Data;
using PostoDeGasolina.Models;

namespace SalesWebMvc.Services
{
    public class VeiculosService
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

	}
}