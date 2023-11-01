using CarServiceBL.IRepository;
using CarServiceBL.Models;
using CarServiceUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CarServiceUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public IBaseRepository<Technician> tecrepo;

        public HomeController(ILogger<HomeController> logger, IBaseRepository<Technician> tecrepo)
        {
            _logger = logger;
            this.tecrepo = tecrepo;
        }

        public IActionResult Index()
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
        public IActionResult About()
        {
            return View(tecrepo.GetAll());
        }
        public IActionResult Contact()
        {
            return View();
        }
    }
}