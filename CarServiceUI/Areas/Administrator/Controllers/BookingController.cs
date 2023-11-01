using CarServiceBL.IRepository;
using CarServiceBL.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarServiceUI.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    public class BookingController : Controller
    {
        public IBaseRepository<Booking> baseRepository;
        public BookingController(IBaseRepository<Booking> _baseRepository)
        {
            baseRepository = _baseRepository;
        } 
        public IActionResult Index()
        {
            return View(baseRepository.GetAll());
        }
    }
}
