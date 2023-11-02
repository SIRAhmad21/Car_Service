using CarServiceBL.IRepository;
using CarServiceBL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarServiceUI.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    [Authorize]
    public class BookingController : Controller
    {
        public IBaseRepository<Booking> baseRepository;
        public BookingController(IBaseRepository<Booking> _baseRepository)
        {
            baseRepository = _baseRepository;
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            return View(baseRepository.GetAll());
        }
    }
}
