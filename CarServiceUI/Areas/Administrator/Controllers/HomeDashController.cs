using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarServiceUI.Areas.Administrator.Controllers
{
    [Authorize]
    [Area("Administrator")]
    public class HomeDashController : Controller
    {

        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Website()
        {
            return RedirectToAction("Index","Home");
        }
    }
}
