using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PostoDeGasolina.Data;
using PostoDeGasolina.Models;
using System.Threading.Tasks;

namespace PostoDeGasolina.Controllers
{
    public class CombustiveisController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CombustiveisController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var combustiveis = await _context.Combustiveis.ToListAsync();
            return View(combustiveis);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Preco")] Combustivel combustivel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(combustivel);
                await _context.SaveChangesAsync();
                ViewBag.Message = "Combustível cadastrado com sucesso!";
            }
            return View(combustivel);
        }
    }
}
