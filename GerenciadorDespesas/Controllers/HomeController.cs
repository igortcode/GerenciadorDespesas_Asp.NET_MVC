using GerenciadorDespesas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;

namespace GerenciadorDespesas.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<string> conhecimentos = new List<string>() {
                "Chamadas Ajax",
                "JSON",
            "View Models",
            "View Component",
            "Partial View",
            "Biblioteca Charts.js",
            "CRUD com EntityFramework",
            "SQLServer",
            "Injeção de dependencia",
            "Validações",
            "Data Annotations",
            "Estrutura de pastas",
            "Mapeamento de Entidades"};

            return View(conhecimentos);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
