using Microsoft.AspNetCore.Mvc;
using Papelaria.Models;
using System.Diagnostics;

namespace Papelaria.Controllers
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
            return View();
        }
        public IActionResult Cliente()
        {
            return View();
        }
        public IActionResult Fornecedor()
        {
            return View();
        }
        public IActionResult CategoriaProd()
        {
            return View();
        }
        public IActionResult Produto()
        {
            return View();
        }
        public IActionResult CadVenda()
        {
            return View();
        }
        public IActionResult CadCompra()
        {
            return View();
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