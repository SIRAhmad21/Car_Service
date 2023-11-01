using Microsoft.AspNetCore.Mvc;

namespace CarServiceUI.Areas.Administrator.Controllers
{
    public class HomeDashController : Controller
    {
        [Area("Administrator")]
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Website()
        {
            return RedirectToAction("Index","Home");
        }
    }
}
