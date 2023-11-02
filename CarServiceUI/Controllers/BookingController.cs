using CarServiceBL.IRepository;
using CarServiceBL.Models;
using CarServiceEF.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarServiceUI.Controllers
{
    [Authorize]
    public class BookingController : Controller
    {
        private IBaseRepository <Booking> _bookingRepository;
        private AppDbContext db;
        public BookingController(IBaseRepository<Booking> baseRepository,AppDbContext _db)
        {
            _bookingRepository = baseRepository;
            db= _db;
        }
        [Authorize(Roles = "User")]
        public IActionResult BookNow ()
        {
            ViewBag.services = new SelectList(db.Services, "ServiceId", "ServiecName");
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "User")]
        public IActionResult BookNow(Booking book)
        {
            _bookingRepository.Add(book);
            return RedirectToAction("Index","Home");
        }
    }
}
