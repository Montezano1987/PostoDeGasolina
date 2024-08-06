using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PostoDeGasolina.Data;
using PostoDeGasolina.Models;
using System.Threading.Tasks;

namespace PostoDeGasolina.Controllers
{
    public class VeiculosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VeiculosController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var veiculos = await _context.Veiculos.ToListAsync();
            return View(veiculos);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Modelo,Marca,Ano")] Veiculo veiculo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(veiculo);
                await _context.SaveChangesAsync();
                ViewBag.Message = "Veículo cadastrado com sucesso!";
            }
            return View(veiculo);
        }
    }
}
