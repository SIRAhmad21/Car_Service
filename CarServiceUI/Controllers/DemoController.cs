using Microsoft.AspNetCore.Mvc;

namespace CarServiceUI.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult ServiceView()
        {
            return View();
        }
    }
}
